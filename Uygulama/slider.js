let sliderIndex = 0
let allSlides= $(".slide").toArray()
let allDots=$(".dot").toArray()
$("#prevSlide").click(function(){

    if(sliderIndex==0){
        sliderIndex=allSlides.length
    }

    showSlide(--sliderIndex)
})
$("#nextSlide").click(function(){
    
    if(sliderIndex==allSlides.length-1){
        sliderIndex=-1
    }

    showSlide(++sliderIndex)
})
$(".dot").click(function(){
    sliderIndex=$(this).index();
    showSlide(sliderIndex)
})

function showSlide(n){
    for(let i=0;i<allSlides.length;i++){
    allSlides[i].style.display="none";
    allDots[i].classList.remove("active")
    }
    $(".slide").eq(n).fadeTo(2000,1)
    allSlides[n].style.display="block"
    allDots[n].classList.add("active");

}

showSlide(sliderIndex)