$.fn.tabs = function () {
	var $this = this,
		$parentNode = $this;
	$this.addClass('tabs-container');

	$this.find('.tab-item-content')
			.hide();

	$this.find('.tab-item-title')
		.on('click', function (ev) {
			var $this = $(this);
			$parentNode.find('.current')
				.removeClass('current');
			$parentNode.find('.tab-item-content')
				.hide();
			$this.parent()
				.addClass('current')
				.find('.tab-item-content')
				.show();
		});
	$this.find('.current .tab-item-title')
		.click();
};












