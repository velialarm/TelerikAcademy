$.fn.tabs = function () {
	var $this = this;
	$this.addClass('tabs-container');
	hideTabControlContent();
	$this.on('click', '.tab-item-title', function(ev){
		var $titleTab = $(this);
		hideTabControlContent();
		$this.find('.tab-item').removeClass('current');
		$titleTab.next().show();
		$titleTab.parent().addClass('current');
	});
	
	function hideTabControlContent(){
		$this.find('.tab-item-content').hide();
	}
};