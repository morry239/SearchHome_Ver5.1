$(document).ready(function () {
    let lineChart1 = null;
    let pieChart1 = null;
    let pieChart2 = null;

    function drawChart(chartInstance, canvasId, chartSettings) {

        if (chartInstance != null) {
            //update chart with new configuration
            chartInstance.options = { ...chartSettings.options };
            chartInstance.data = { ...chartSettings.data };

            chartInstance.update();
            return chartInstance;
        } else {
            //create new chart.
            var ctx = document.getElementById(canvasId).getContext('2d');
            return new Chart(ctx, chartSettings);
        }
    }

    function buildSelectFilter(years, currentYear) {
        //clear all options.
        $("#filterByYear").empty();
        var selectOptionsFilterHtml = "";

        if (years) {
            years.forEach((year) => {
                selectOptionsFilterHtml += `<option value="${year}" 
                      ${currentYear == year ? 'selected':''}>${year}</option>`
            });
        }

        $("#filterByYear").append(selectOptionsFilterHtml);
    }

    function makeRandomColor() {
        return "#" + Math.floor(Math.random() * 16777215).toString(16);
    }

    function drawLineChart(chartInstance, canvasId, data, titleText) {

        let settings = {
            // The type of chart we want to create
            type: 'line',
            // The data for our dataset
            data: {
                datasets: [{
                    backgroundColor: 'rgba(255,0,0,0)',
                    borderColor: makeRandomColor(),
                    data: data
                }]
            },

            // Configuration options go here
            options: {
                legend: {
                    display: false
                },

                title: {
                    display: true,
                    text: titleText,
                    fontSize: 16
                },
                scales: {
                    xAxes: [{
                        type: 'time',
                        time: {
                            unit: 'month',
                            displayFormats: {
                                month: 'MM YYYY'
                            }
                        }
                    }]
                }
            }
        };

        return drawChart(chartInstance, canvasId, settings);
    }

    function drawPieChart(chartInstance, canvasId, data, labels, titleText) {

        //generate random color for each label.
        let bgColors = [];

        if (labels) {
            bgColors = labels.map(() => {
                return makeRandomColor();
            });
        }

        var settings = {
            // The type of chart we want to create
            type: 'pie',

            // The data for our dataset
            data: {
                labels: labels,
                datasets: [{
                    backgroundColor: bgColors,
                    borderColor: bgColors,
                    data: data
                }],
            },

            // Configuration options go here
            options: {
                tooltips: {
                    callbacks: {
                        label: function (tooltipItem, data) {
                            //create custom display.
                            var label = data.labels[tooltipItem.index] || '';
                            var currentData = data.datasets[0].data[tooltipItem.index];

                            if (label) {
                                label = `${label} ${Number(currentData)} %`;
                            }

                            return label;
                        }
                    }
                },
                title: {
                    display: true,
                    text: titleText,
                    fontSize: 16
                },
            }
        };

        return drawChart(chartInstance, canvasId, settings);
    }

    function filterDashboardDataByYear(currentYear) {

        currentYear = currentYear || '';
        let url = `http://localhost:65105/api/dashboard/${currentYear}`;

        $.get(url, function (data) {

            if (!currentYear && data.years.length > 0) {
                //pick the last year.
                currentYear = data.years.reverse()[0];
            }

            buildSelectFilter(data.years, currentYear);

            let data1 = [];
            if (data.subscribedUsersForYearGroupedByMonth) {
                data1 = data.subscribedUsersForYearGroupedByMonth.map
                (u => { return { "x": moment(u.x, "YYYY-MM-DD"), "y": u.y } });
            }

            let data2 = [];
            let labels2 = [];
            if (data.subscribedUsersForYearGroupedByGender) {
                data2 = data.subscribedUsersForYearGroupedByGender.map(u => u.value);
                labels2 = data.subscribedUsersForYearGroupedByGender.map(u => u.label);
            }

            let data3 = [];
            let labels3 = [];
            if (data.subscribedUsersForYearGroupedByProfession) {
                data3 = data.subscribedUsersForYearGroupedByProfession.map(u => u.value);
                labels3 =
                    data.subscribedUsersForYearGroupedByProfession.map(u => u.label);
            }

            lineChart1 = drawLineChart(lineChart1, "mylineChart1", data1,
                `Number of subscribed users per month in ${currentYear}`);
            pieChart1 = drawPieChart(pieChart1, "mypieChart1", data2, labels2,
                `Number of subscribed users in ${currentYear} 
                         grouped by gender`);
            pieChart2 = drawPieChart(pieChart2, "mypieChart2", data3, labels3,
                `Number of subscribed users in 
                         ${currentYear} grouped by profession`);
        });
    }

    filterDashboardDataByYear();

    $(document).on("change", "#filterByYear", function () {
        filterDashboardDataByYear(parseInt($(this).val()));
    });
});