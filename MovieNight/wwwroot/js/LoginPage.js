jQuery(document).ready(function ($) {
	tab = $('.tabs h3 a');

	tab.on('click', function (event) {
		event.preventDefault();
		tab.removeClass('active');
		$(this).addClass('active');

		tab_content = $(this).attr('href');
		$('div[id$="tab-content"]').removeClass('active');
		$(tab_content).addClass('active');
	});
});

//document.getElementById('birthdate').addEventListener('change', function () {
//	var label = document.getElementById('birthdate-label');
//	if (this.value) {
//		label.style.visibility = 'hidden';
//	} else {
//		label.style.visibility = 'visible';
//	}
//});

//document.addEventListener('DOMContentLoaded', (event) => {
//    var dateInput = document.getElementById('birthdate');

//    dateInput.addEventListener('focus', function(){
//        this.type = 'date';
//    });

//    dateInput.addEventListener('blur', function(){
//        if (!this.value) {
//            this.type = 'text';
//        }
//    });
//});





