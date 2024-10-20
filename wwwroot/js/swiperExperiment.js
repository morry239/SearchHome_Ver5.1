import Swiper from 'swiper/bundle';
import 'swiper/css/bundle';
const swiper = new Swiper('.swiper', {
    direction: 'vertical',
    loop:true,
    
    pagination: {
        el: '.swiper-pagination',
    },
    
    navigation: {
        nextEl: '.swiper-button-next'
    }
});