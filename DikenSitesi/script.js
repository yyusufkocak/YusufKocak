let sliderIndex = 0;
let allSlides = $(".slide").toArray();
let allDots = $(".dot").toArray();

$("#prevSlide").click(function(){
    if (sliderIndex==0) {
        sliderIndex=allSlides.length
    }
    showSlide(--sliderIndex);
})

$("#nextSlide").click(function(){
    if (sliderIndex==allSlides.length-1) {
        sliderIndex=-1;
    }
    showSlide(++sliderIndex);
})

$(".dot").click(function(){
    sliderIndex=$(this).index();
    showSlide(sliderIndex);
})
function showSlide(n){
    for(let i=0; i < allSlides.length; i++){
        //allSlides[i].style.display="none";
        $(".slide").eq(i).hide();
        allDots[i].classList.remove("active");
        
    }
    //allSlides[n].style.display="block";
    $(".slide").eq(n).fadeTo(1000,0.8);
    allDots[n].classList.add("active");
    
}

showSlide(sliderIndex);