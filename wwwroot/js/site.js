$(document).ready(function() {
    $("saveBtn").click(function(){
        var val = listingId;

        $.ajax({
            type:"POST",
            url: '@Url.Action("InsertListings", "Home")?IntegrationPoint=' + val,
            dataType: 'json',
            data:{String:val}
        })
            .fail(function(){alert("fail")})
            .done(function(){alert("success")})

    });
});