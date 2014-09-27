function createCalendar(selector, events) {
	var container = document.querySelector(selector);
	var dayBox = document.createElement('div');
	var dayBoxTitle = document.createElement('strong');
	var dayBoxContent = document.createElement('div');

	//hack to fix the jumping of the empty boxes
	dayBoxContent.innerHTML = '&nbsp;';

	var daysOfWeek = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
	var DAYS_IN_MONTH_COUNT = 30;

	var selectedBox = null;

	//styles
	container.style.width = (120 * 7.5) + 'px';

	dayBox.style.display = 'inline-block';
	dayBox.style.margin = '0';
	dayBox.style.padding = '0';
	dayBox.style.border = '1px solid purple';
	dayBox.style.width = '120px';
	dayBox.style.height = '120px';

	dayBoxTitle.style.display = 'block';
	dayBoxTitle.style.background = 'green';
	dayBoxTitle.style.textAlign = 'center';
	dayBoxTitle.style.color = 'pink';
	dayBoxTitle.style.borderBottom = '1px solid purple';


	dayBoxTitle.className = 'day-title';
	dayBoxContent.className = 'day-content';

	dayBox.appendChild(dayBoxTitle);
	dayBox.appendChild(dayBoxContent);

	function createMonthBoxes(daysInMonthCount, daysOfWeek) {
		var dayBoxes = [];
		for (var i = 0; i < daysInMonthCount; i += 1) {
			var dayOfWeek = daysOfWeek[i % daysOfWeek.length];
			dayBoxTitle.innerHTML = dayOfWeek + ' ' + (i + 1) + ' Jun 2014';
			dayBoxes.push(dayBox.cloneNode(true));
		}
		return dayBoxes;
	}

	function addCalendarEvents(boxes, events) {
		for (var i = 0; i < events.length; i += 1) {
			var event = events[i];
			var content = boxes[event.date - 1].querySelector('.day-content');
			content.innerHTML = event.time + ' ' + event.title;
		}
	}

	function onBoxMouseover(ev) {
		if (selectedBox !== this) {
			this.style.background = 'gold';
		}
	}

	function onBoxMouseout(ev) {
		if (selectedBox !== this) {
			this.style.background = '';
		}
	}

	function onBoxClick(ev) {
		if (selectedBox) { //no box is selected
			selectedBox.style.background = '';
		}
		if (selectedBox && selectedBox === this) {
			selectedBox = null;
		} else {
			this.style.background = 'yellowgreen';
			selectedBox = this;
		}
	}

	var boxes = createMonthBoxes(DAYS_IN_MONTH_COUNT, daysOfWeek);
	addCalendarEvents(boxes, events);

	var docFragment = document.createDocumentFragment();

	for (var i = 0; i < boxes.length; i += 1) {
		docFragment.appendChild(boxes[i]);
		boxes[i].addEventListener('click', onBoxClick);
		boxes[i].addEventListener('mouseover', onBoxMouseover);
		boxes[i].addEventListener('mouseout', onBoxMouseout);
	}
	container.appendChild(docFragment);
}