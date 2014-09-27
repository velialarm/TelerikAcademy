function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector);
    container.style.width = '600px';
    container.style.height = '400px';
    //container.style.border = '1px solid black';
    //container.style.backgroundColor = '#CCC'; //remove me !

    var frag = document.createDocumentFragment();

    var resArr = items.slice();


    var leftContainer = document.createElement('div');
    var rightContainer = document.createElement('div');
    var mainHolder = document.createElement('div');
    var listHolder = document.createElement('div');
    var listBlockElement =  document.createElement('div');
    var inputFilterEl = document.createElement('input');
    var inputTitle = document.createElement('p');
    var titleBlockListEl = document.createElement('h3');
    var imageBlockListEl = document.createElement('img');
    var mainBoxTitle = document.createElement('h1');
    var mainBoxImage = document.createElement('img');

    applyLeftContainerStyle(leftContainer);
    applyRightContainerStyle(rightContainer);
    applyMainHolderStyle(mainHolder);
    applyListHolderStyle(listHolder);
    applyInputStyle(inputFilterEl);
    applyListBlockElementStyle(listBlockElement);
    applyinputTitle(inputTitle);
    titleBlockListElStyle(titleBlockListEl);
    imageBlockListElStyle(imageBlockListEl);
    mainBoxTitleStyle(mainBoxTitle);
    mainBoxImageStyle(mainBoxImage);

    createMainBoxView();
    leftContainer.appendChild(mainHolder);
    frag.appendChild(leftContainer);

    createListBlockElements();
    frag.appendChild(rightContainer);
    container.appendChild(frag);


    function createMainBoxView(){
        mainBoxTitle.innerText = resArr[0].title;
        mainHolder.appendChild(mainBoxTitle);
        mainBoxImage.src = resArr[0].url;
        mainHolder.appendChild(mainBoxImage);
    }

    function changeMainBoxView(title, url){
        mainBoxTitle.innerText = title;
        mainBoxImage.src = url;
    }

    function createListBlockElements(){
        inputTitle.innerText = 'Filter';
        rightContainer.appendChild(inputTitle);
        inputFilterEl.addEventListener('input',filterBox);
        rightContainer.appendChild(inputFilterEl);
        for (var i = 0; i < resArr.length; i++) {
            var test = resArr[i];
            //console.log(test.title);
            var cloneListBlockEl = listBlockElement.cloneNode(true);
            var titleBlEl = titleBlockListEl.cloneNode(true);
            titleBlEl.innerText = resArr[i].title;
            var imgBlEl = imageBlockListEl.cloneNode(true);
            imgBlEl.src =  resArr[i].url;
            cloneListBlockEl.appendChild(titleBlEl);
            cloneListBlockEl.appendChild(imgBlEl);

            cloneListBlockEl.addEventListener('click', onBoxClick);
            cloneListBlockEl.addEventListener('mouseover', onBoxMouseover);
            cloneListBlockEl.addEventListener('mouseout', onBoxMouseout);

            cloneListBlockEl.classList.add('filterStyle');


            rightContainer.appendChild(cloneListBlockEl);
        }
    }
    function filterBox(ev){
        var inputValue = ev.target.value;
        var allEl = document.getElementsByClassName('filterStyle');
        if(inputValue != ''){
            for (var i = 0; i < allEl.length; i++) {
                var obj = allEl[i];
                var sourseTitle = obj.children[0].innerText;
                var myRegExp = new RegExp("(.*?)("+inputValue.toLowerCase()+")(.*?)");
                if(!myRegExp.test(sourseTitle.toLowerCase())){
                    obj.style.display = 'none';
                }else{
                    obj.style.display = 'block';
                }
            }
        }else{
            for (var i = 0; i < allEl.length; i++) {
                var obj = allEl[i];
                obj.style.display = 'block';
            }
        }

    }
    function onBoxClick(ev){
        var title = this.children[0].innerText;
        var url = this.children[1].src;
        changeMainBoxView(title, url);
    }
    function onBoxMouseover(ev){
        this.style.backgroundColor = '#CCC';
    }
    function onBoxMouseout(ev){
        this.style.backgroundColor = 'white';
    }

    function applyLeftContainerStyle(el) {
        el.style.float = 'left';
        el.style.width = '430px';
        el.style.height = '400px';
        el.style.backgroundColor = 'white'; //remove me !
    }

    function applyRightContainerStyle(el) {
        el.style.float = 'left';
        el.style.width = '160px';
        el.style.height = '400px';
        el.style.overflow = 'auto';
        el.style.padding = '0px 5px';
       // el.style.backgroundColor = 'red'; //remove me !
    }
    function applyMainHolderStyle(el) {
        el.style.padding = '20px';
    }
    function applyListHolderStyle(el) {

    }
    function applyListBlockElementStyle(el){
        el.style.width = '130px';
        el.style.backgroundColor = 'white';
        //el.style.border = '1px solid black';
        el.style.padding = '5px';
    }
    function applyInputStyle(el){
        el.style.width = '138px';
    }
    function applyinputTitle(el){
        el.style.textAlign = 'center';
        el.style.padding = '0px';
        el.style.margin = '0px';
        el.style.fontSize = '16px';
    }
    function imageBlockListElStyle(el){
        el.style.width = '100%';
        el.style.height = 'auto';
        el.style.borderRadius ='5px';
    }
    function titleBlockListElStyle(el){
        el.style.textAlign = 'center';
        el.style.padding = '0px';
        el.style.margin = '0px';
        el.style.fontSize = '16px';
    }

    function mainBoxTitleStyle(el){
        el.style.textAlign = 'center';
    }
    function mainBoxImageStyle(el){
        el.style.width = '100%';
        el.style.height = 'auto';
        el.style.borderRadius ='15px';
    }
}