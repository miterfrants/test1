$(function(){
	$(window)._scrollable(); // When scrolling the window
	$('section').css('min-height', $(window).height());

	var $paneTarget = $('body');
	$('#nav-land').click(function(){
		$paneTarget.stop().scrollTo($('#landing'),800);
	});
	$('#nav-what').click(function(){
		$paneTarget.stop().scrollTo($('#what-is-soda'),800);
	});
	$('#nav-places').click(function(){
		$paneTarget.stop().scrollTo($('#places'),800);
	});
	$('#nav-me-there').click(function(){
		$paneTarget.stop().scrollTo($('#take-me-there'),800);
	});
});