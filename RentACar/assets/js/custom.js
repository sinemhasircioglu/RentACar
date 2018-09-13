var App = (function(window){
  "use strict";
  var _this = null;
  var cacheCollection = {};
  return{
    init : function(){
      _this = this;

      /* DRIVER CAROUSEL */
      this.DriverCarousel();
      this.BestOffters();
      this.DriverRowCarousel();
      this.LatestNewsCarousel();

      /* CUSTOM ACCORDION */
      this.CustomAccordion();

      /* DEFAULT CUSTOM ACCORDION */
      this.DefaultCustomAccordion();

      /* CAR PRODUCT CAROUSEL */
      this.CarProductSlider();

      /* PRODUCT TESTIMONIAL CAROUSEL */
      this.ProductTestimonial();

      /* SIMILAR PRODUCT CAROUSEL */
      this.SimilarProductCarousel();

      /* DEFAULT HOME CAROUSEL */
      this.DefaultHomeCarousel();

      /* MENU TOGGLE */
      this.ToggleMenu();

      /* SUB MENU TOGGLE */
      this.MenuDropIcon();

      /* DATE TIME PICKER */
      this.DateTimePicker();
  
      /* MAP TOGGLE */
      this.MapToggle();

      /* BEST TAB */
      this.BestTab(); 

      /* COLOR SWITCHER */
      this.ColorSwitcher(); 

      /* BACK TO TOP */
      this.BackToTop();

      /* SET SEARCH TOP MARGIN  */
      this.SearchMargin();

      /* TOGGLE SEARCH AREA  */
      this.SearchToggle();

      /* ACTIVATE COUNTER  */
      this.StartCounter();

    },

    getObject: function(selector){
      if(typeof cacheCollection[selector] == "undefined"){
        cacheCollection[selector] = $(selector);
      }
      return cacheCollection[selector];
    },


    DriverCarousel: function(){
      if($("#r-driver-slider").length > 0){
        var owl = $('#r-driver-slider').owlCarousel({
            loop:true,
            margin:0,
            items: 3,
            nav: false,
            dots: true,
            responsive:{
                0:{
                    items:1
                },
                600:{
                    items:2
                },
                1000:{
                    items:3
                }
            }
        })
      }
    },

    LatestNewsCarousel: function(){
      if($("#r-latest-news-slider").length > 0){
        var owl = $('#r-latest-news-slider').owlCarousel({
            loop:true,
            margin: 30,
            items: 3,
            nav: false,
            dots: true,
            autoplay: true,
            autoplayTimeout:5000,
            autoplayHoverPause: true,
            responsive:{
                0:{
                    items:1
                },
                600:{
                    items:2
                },
                1000:{
                    items:3
                }
            }
        })
      }
    },

    DriverRowCarousel: function(){
      if($("#r-driver-row-slider").length > 0){
        var owl = $('#r-driver-row-slider').owlCarousel({
            loop:true,
            margin:0,
            items: 1,
            nav: false,
            dots: true,
        })
      }
    },

    BestOffters: function(){
      if($("#r-best-offers").length > 0){
        var owl = $('#r-best-offers').owlCarousel({
            loop:true,
            margin:15,
            items: 3,
            nav: false,
            dots: true,
            responsive:{
                0:{
                    items:1
                },
                600:{
                    items:2
                },
                1000:{
                    items:3
                }
            }
        })
      }
    },

    DefaultCustomAccordion: function(){
      $(document).on('click','.r-accordion-header', function(){
        var accordionBody = $(this).next('.r-accordion-body');
        $(this).parents('div.col-lg-6.col-md-12').find(".r-accordion-body").slideUp();
        if(accordionBody.is(':hidden')){
          accordionBody.slideDown();
          $(this).find('i').toggleClass('fa-angle-up fa-angle-down');
        }
        else{
          accordionBody.slideUp();
          $(this).find('i').toggleClass('fa-angle-up fa-angle-down');
        }

      });
    },
    
    CustomAccordion: function(){
      $(document).on('click','.r-accordion-heading', function(){ console.log("111");
        var accordionBody = $(this).next('.r-accordion-body');
        $(this).parents('div.col-lg-6.col-md-12').find(".r-accordion-body").slideUp();
          $(this).parents('div.col-lg-6.col-md-12').find('i').removeClass('fa-arrow-circle-up');
          $(this).parents('div.col-lg-6.col-md-12').find('i').addClass('fa-arrow-circle-down');
        if(accordionBody.is(':hidden')){
          accordionBody.slideDown();
          $(this).find('i').toggleClass('fa-arrow-circle-up');
          $(this).find('i').toggleClass('fa-arrow-circle-down');
          $(this).find('.r-accordion-icon').attr('src','assets/images/accordion-open-icon.jpg');
        }
        else{
          accordionBody.slideUp();
          $(this).find('i').toggleClass('fa-arrow-circle-up');
          $(this).find('i').toggleClass('fa-arrow-circle-down');
          $(this).find('.r-accordion-icon').attr('src','assets/images/accordion-icon.jpg');
        }

      });
    },

    CarProductSlider: function(){
      if($("#productSlider").length > 0){
        var owl =  $('#productSlider').owlCarousel({
          loop:true,
          margin: 0,
          items: 1,
          auto: false,
          dots: false,
          autoplay: false,
          nav: false,
          mouseDrag: false,
          touchDrag: false,
          thumbs: true,
          thumbsPrerendered: true
        });
      }
      if($("#productSlider-01").length > 0){
        var owl =  $('#productSlider-01').owlCarousel({
          loop:true,
          margin: 0,
          items: 1,
          auto: false,
          dots: false,
          autoplay: false,
          nav: false,
          mouseDrag: false,
          touchDrag: false,
          thumbs: true,
          thumbsPrerendered: true
        });
      }
      if($("#productSlider-02").length > 0){
        var owl =  $('#productSlider-02').owlCarousel({
          loop:true,
          margin: 0,
          items: 1,
          auto: false,
          dots: false,
          autoplay: false,
          nav: false,
          mouseDrag: false,
          touchDrag: false,
          thumbs: true,
          thumbsPrerendered: true
        });
      }
      if($("#productSlider-03").length > 0){
        var owl =  $('#productSlider-03').owlCarousel({
          loop:true,
          margin: 0,
          items: 1,
          auto: false,
          dots: false,
          autoplay: false,
          nav: false,
          mouseDrag: false,
          touchDrag: false,
          thumbs: true,
          thumbsPrerendered: true
        });
      }
    },

    ProductTestimonial: function(){
      if($("#productTestimonial").length > 0){
        var owl =  $('#productTestimonial').owlCarousel({
          loop:true,
          margin: 0,
          items: 1,
          auto: true,
          dots: true,
          autoplay: true,
          nav: false
        });
      }
    },

    DefaultHomeCarousel: function(){
      if($("#defaultHomeSlider").length > 0){
        var owl =  $('#defaultHomeSlider').owlCarousel({
          loop:true,
          margin: 0,
          items: 1,
          auto: true,
          dots: true,
          autoplay: true,
          nav: true,
          navText: ['<i class="fa fa-caret-left"></i>', '<i class="fa fa-caret-right"></i>']
        });
        owl.on("changed.owl.carousel", function(event){
            // selecting the current active item
            var item = event.item.index-2;
            // first removing animation for all captions
            $('.r-slider-top-content h1').removeClass('animated fadeInDown');
            $('.r-slider-top-content h4').removeClass('animated fadeInLeft');
            $('.r-slider-top-content a').removeClass('animated fadeInUp');
            $('#defaultHomeSlider .owl-item').not('.cloned').eq(item).find('h1').addClass('animated fadeInDown');
            $('#defaultHomeSlider .owl-item').not('.cloned').eq(item).find('h4').addClass('animated fadeInLeft');
            $('#defaultHomeSlider .owl-item').not('.cloned').eq(item).find('a').addClass('animated fadeInUp');
        })
      }
    },

    SimilarProductCarousel: function(){
      if($("#similarProductCarousel").length > 0){
        var owl =  $('#similarProductCarousel').owlCarousel({
          loop:true,
          margin: 30,
          items: 1,
          auto: false,
          dots: true,
          autoplay: false,
          nav: false,
          responsive:{
              0:{
                  items:1
              },
              600:{
                  items:2
              },
              1000:{
                  items:3
              }
          }
        });
      }
      if($("#similarProductCarousel-01").length > 0){
        var owl =  $('#similarProductCarousel-01').owlCarousel({
          loop:true,
          margin: 30,
          items: 1,
          auto: false,
          dots: true,
          autoplay: false,
          nav: false,
          responsive:{
              0:{
                  items:1
              },
              600:{
                  items:2
              },
              1000:{
                  items:3
              }
          }
        });
      }
      if($("#similarProductCarousel-02").length > 0){
        var owl =  $('#similarProductCarousel-02').owlCarousel({
          loop:true,
          margin: 30,
          items: 1,
          auto: false,
          dots: true,
          autoplay: false,
          nav: false,
          responsive:{
              0:{
                  items:1
              },
              600:{
                  items:2
              },
              1000:{
                  items:3
              }
          }
        });
      }
      if($("#similarProductCarousel-03").length > 0){
        var owl =  $('#similarProductCarousel-03').owlCarousel({
          loop:true,
          margin: 30,
          items: 1,
          auto: false,
          dots: true,
          autoplay: false,
          nav: false,
          responsive:{
              0:{
                  items:1
              },
              600:{
                  items:2
              },
              1000:{
                  items:3
              }
          }
        });
      }
    },

    ToggleMenu: function(){
      $(document).on('click', '.menu-icon', function(){
        $('.r-nav-section').slideToggle();
      });
    },

    DateTimePicker: function(){
      if($('#datetimepicker3').length > 0){
        $('#datetimepicker3').datetimepicker({
            format: 'LT'
        });
        $('#datetimepicker2').datetimepicker({
            format: 'L'
        });
        $('#datetimepicker5').datetimepicker({
            format: 'LT'
        });
        $('#datetimepicker4').datetimepicker({
            format: 'L'
        });
      }
    },

  MapToggle: function(){
      $(document).on("click", ".r-flip-map", function(){
        var list_width = $(".r-list-area").outerWidth();
        var list_width = list_width + 5;
        console.log(list_width);
        $(".r-list-area").css("margin-left", "-"+list_width+"px");
        $(".r-map-area").addClass("r-map-full");
        $(this).addClass('r-flip-active');
        $(this).removeClass('r-flip-map');
      });
      $(document).on("click", ".r-flip-active", function(){ 
        $(".r-list-area").css("margin-left", 'auto');
        $(".r-map-area").removeClass("r-map-full");
        $(this).removeClass('r-flip-active');
        $(this).addClass('r-flip-map'); 
      });
    },

    MenuDropIcon: function(){
      $('.r-has-child').each(function(){
        $(this).append('<span class="r-submenu-icon"> <i class="fa fa-angle-down"></i> </span>')
      });

      $(document).on('click', '.r-submenu-icon', function(){
        var subMenu = $(this).prev('ul');
        
        if(subMenu.is(':hidden')){
          subMenu.show();
        }
        else{
          subMenu.hide();
        }

      });

    },

    BestTab: function(){
      $(".r-best-leftbar ul li").on("click", function(){
        var id = $(this).attr("data-tab"); 
        $(".r-best-leftbar ul li").removeClass("r-best-vehicle-acitve");
        $(this).addClass("r-best-vehicle-acitve");
        $(".r-best-tab-outer > div").addClass("d-none");
        $(".r-best-tab-outer > div[data-tab-attr="+id+"]").removeClass("d-none");
      });
    },

    ColorSwitcher: function(){
      $("#r-color_selector > li").on("click", function(){
        var color_id = $(this).attr("data-attr");
        $("#r-color_selector > li").removeClass("r-active-color");
        $(this).addClass("r-active-color");
        $(document).find("link#r-color-roller").attr("href","");
        $(document).find("link#r-color-roller").attr("href","assets/color-files/"+color_id+".css") 
      })
      $("#r-selector_icon").on("click", function(){
        $("#r-customizer").toggleClass("r-customizer_toggle");
      })
    },

    BackToTop: function(){
      $(window).on("scroll", function () {
          if ($(this).scrollTop() > 1) {
              $("#r-to-top").css({right: '25px'});
          } else {
              $("#r-to-top").css({right: '-150px'});
          }
      });
      $("#r-to-top").on('click', function(){
          $('html, body').animate({scrollTop: '0px'}, 800);
          return false;
      });
    },

    SearchMargin: function(){
      var headerHeight = $('.r-header-strip').outerHeight() + 50;
      $('.r-search-wrapper').css({'top' : headerHeight + 'px'});
    },

    SearchToggle: function(){
      $(document).on('click', '.r-search', function(evt){
        evt.preventDefault();
        $('.r-search-wrapper').toggleClass('r-search-open');
      });
    },

    StartCounter: function(){
      if($('.r-counter-section').length > 0){
        $('.r-counter-section').appear(function(){
          var counterUp =
            $('.r-counter-section .r-counts').each(function(){
            var countNum = $(this).attr('data-count');
            var view = $(this).find('.r-count');
            $(view).counter({
                autoStart: true,
                duration: 2000,
                countTo: countNum,
                placeholder: 0,
                easing: "easeOutCubic"
            });
          });
        });
      }
    }

  }
})(window);


$(document).ready(function($) {
  App.init();

  /* ToolTip */
  if($('a[data-rel^=lightcase]').length > 0){
    $('[data-toggle="tooltip"]').tooltip();
  }

  if($(".gallery").length > 0){
    var $gallery = $('.gallery a').simpleLightbox();
  }
  if($("a[data-rel^=lightcase]").length > 0){
    $('a[data-rel^=lightcase]').lightcase();
  }

 

});

$(window).on('scroll', function(){
  var wScroll = $(window).scrollTop();
  var halfwHeight = $(window).height()/2;

  if(wScroll > halfwHeight){
    $('.r-header-strip').addClass('r-header-fixed');
  }
  else{
    $('.r-header-strip').removeClass('r-header-fixed');
  }
});



