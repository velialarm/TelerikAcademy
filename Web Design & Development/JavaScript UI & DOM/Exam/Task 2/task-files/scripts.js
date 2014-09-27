$.fn.gallery = function (option) {
    var LAST_IMAGE_VALUE = 12;
    var FIRST_IMAGE_VALUE = 1;
    var currentImageValue = 1;
    $this = this;
    var columns = parseInt(option) || 4;
    $this.addClass('gallery');
    $('.gallery').css('width', columns * 260);
    $('.selected').hide();

    $('.image-container').on('click',function(ev){
        $('.gallery-list').addClass('blurred');
        $('.selected').show();
        currentImageValue = parseInt($(ev.target).data('info'));
        $($('.current-image').children()[0]).attr("src",('imgs/'+currentImageValue+'.jpg'));
        $('#previous-image').show();
        $('#next-image').show();
        if(currentImageValue > FIRST_IMAGE_VALUE ){
            $('#previous-image').attr("src",('imgs/'+ (currentImageValue - 1) + '.jpg'));
        }else{
            $('#previous-image').hide();
        }
        if(currentImageValue != LAST_IMAGE_VALUE){
            $('#next-image').attr("src",('imgs/'+(currentImageValue + 1) + '.jpg'));
        }else{
            $('#next-image').hide();
        }
    });

    $('.next-image').on('click', function(){
        if(currentImageValue != LAST_IMAGE_VALUE-1){
            $('#next-image').show();

        }else{
            $('#next-image').hide();
        }
        if(currentImageValue < FIRST_IMAGE_VALUE ){
            $('#previous-image').hide();
        }else{
            $('#previous-image').show();
        }
        $('#previous-image').attr("src",('imgs/'+ (currentImageValue) + '.jpg'));
        $('#current-image').attr("src",('imgs/'+(currentImageValue + 1) + '.jpg'));
        $('#next-image').attr("src",('imgs/'+(currentImageValue + 2) + '.jpg'));
        currentImageValue++;

    });
    $('.previous-image').on('click', function(){
        if(currentImageValue == FIRST_IMAGE_VALUE+1 ){
            $('#previous-image').hide();
        }else{
            $('#previous-image').show();
        }
        if(currentImageValue < LAST_IMAGE_VALUE+1){
            $('#next-image').show();

        }else{
            $('#next-image').hide();
        }

        $('#previous-image').attr("src",('imgs/'+ (currentImageValue-2) + '.jpg'));
        $('#current-image').attr("src",('imgs/'+(currentImageValue -1) + '.jpg'));
        $('#next-image').attr("src",('imgs/'+(currentImageValue) + '.jpg'));
        currentImageValue--;
    });

    $('.current-image').on('click',function(){
        $('.selected').hide();
        $('.gallery-list').removeClass('blurred');
    });

};