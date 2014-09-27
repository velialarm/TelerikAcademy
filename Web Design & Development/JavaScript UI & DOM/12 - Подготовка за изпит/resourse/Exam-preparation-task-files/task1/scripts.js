function createCalendar(selector, events){
    var calendar = document.querySelector(selector);

    var WEEKS = 5;
    var MONTH = 'June';
    var YEAR = '2014';
    var WEEKS_DAYS = ['Sat','Sun','Mon','Thu','Wed','Thu','Fri'];
    var MAX_MONTH_DAYS = 30;

    var day = document.createElement('div');
    var week = document.createElement('div');
    var dayTitle = document.createElement('h4');
    var dayEvents = document.createElement('span');

    applyDayStyle(day);
    applyWeekStyle(week);
    applyDayTitleStyle(dayTitle);

    var preparedEvents = prepareEvent(events);
    var month = generateMonth();

    calendar.appendChild(month);

    calendar.addEventListener('click', function(ev){
        if(ev.target.classList.contains('calendar-day')){
            console.log(ev.target);

        }
    });

    function prepareEvent(ev){
        var result = [];
        for (var i = 0; i < events.length; i++) {
            var currentDate = events[i].date;
            result[currentDate] = events[i];
        }
        return result;
    }

    function getCurrentEvent(date, element){
        var currentDateEvent = preparedEvents[date];
        if(currentDateEvent){
            var currentDayEvent = dayEvents.cloneNode(true);
            currentDayEvent.innerText = currentDateEvent.title;
            currentDayEvent.style.display = 'table';
            element.appendChild(currentDayEvent);
        }

        return preparedEvents[date];
    }

    function generateMonth(){
        var frag = document.createDocumentFragment();
        for(var i = 0; i< WEEKS; i++){
            var startDay = i * 7 +1;
            var endDay = startDay + 6;
            var currentWeek = generateWeek(startDay, endDay);
            frag.appendChild(currentWeek);
        }
        return frag;
    }
    function generateWeek(startDay, endDay){
        var currentWeek = week.cloneNode(true);
        for(var i = startDay; i<= endDay && i<= MAX_MONTH_DAYS; i++){
            var currentDay = generateDay(i);
            currentWeek.appendChild(currentDay);
        }
        return currentWeek;
    }

    function generateDay(date){
        var currentDay = day.cloneNode(true);
        var currentDatTitle = generateDayTitle(date);
        currentDay.appendChild(currentDatTitle);
        getCurrentEvent(date,currentDay);
        return currentDay;
    }
    function generateDayTitle(date){
        var currentDayTitle = dayTitle.cloneNode(true);
        var curDayAsAString = WEEKS_DAYS[date % 7];
        currentDayTitle.innerText = curDayAsAString + ' ' + MONTH + ' ' + YEAR;
        return currentDayTitle;
    }

    function applyDayStyle(day) {
        day.classList.add('calendar-day');

        day.style.display = 'inline-block';
        day.style.width = '150px';
        day.style.height = '150px';
        day.style.border = '1px solid black';
    }
    function applyWeekStyle(week) {
        week.style.display = 'block';
    }
    function applyDayTitleStyle(dayTitle){
        dayTitle.style.background = '#CCC';
        dayTitle.style.borderBottom = 'solid 1px black';
        dayTitle.style.margin = '0px';
        dayTitle.style.textAlign = 'center';
    }
}

