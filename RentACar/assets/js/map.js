jQuery(document).ready(function () {
     if (typeof google === 'object' && typeof google.maps === 'object') {
        if ($('#map-canvas').length) {

            var map;
            var marker, marker2, marker3, marker4, marker5, marker6, marker7, marker8;
            var infowindow;
            var mapIWcontent = '' +
                    '' +
                    '<div class="r-best-offer-single">'+
                        '<div class="r-best-offer-in">'+
                          '<div class="r-offer-img">'+
                            '<a class="d-inline-block" href="#"><img src="assets/images/best-02.jpg" class="img-fluid d-block m-auto" alt=""></a>'+
                            '<div class="r-offer-img-over">'+
                              '<i class="fa fa-search"></i>'+
                            '</div>'+
                          '</div>'+
                          '<div class="r-best-offer-content">'+
                            '<a href="#"><b>Hyundai</b> Z.E</a>'+
                            '<p>Start at <b>45.00 USD</b> per day</p>'+
                            '<ul class="pl-0 mb-0">'+
                              '<li><i class="fa fa-car"></i><span>2017</span></li>'+
                              '<li><i class="fa fa-cogs"></i><span>MANUAL</span></li>'+
                              '<li><i class="fa fa-beer"></i><span>PETROL</span></li>'+ 
                            '</ul>'+
                          '</div>'+
                          '<div class="r-offer-rewst-this">'+
                            '<span class="text-uppercase">Rent this car</span>'+
                          '</div>'+
                        '</div>'+
                    '</div>'+
                    '';
            var contentString = '' +
                    '' +
                    '<div class="iw-container">' +
                    '<div class="iw-content">' +
                    '' + mapIWcontent +
                    '</div>' +
                    '<div class="iw-bottom-gradient"></div>' +
                    '</div>' +
                    '' +
                    '';
             var window_width = $(window).width();
             if(window_width > 767){
                var image = {
                 url: "assets/images/icon-google-map.png", // url
                 scaledSize: new google.maps.Size(95, 103), // size
                 origin: new google.maps.Point(0,0), // origin
                 anchor: new google.maps.Point(0, 0) // anchor 
                };
            }else{
                var image = {
                 url: "assets/images/icon-google-map.png", // url
                 scaledSize: new google.maps.Size(50, 54), // size
                 origin: new google.maps.Point(0,0), // origin
                 anchor: new google.maps.Point(0, 0) // anchor 
                }; 
            }
            google.maps.event.addDomListener(window, 'load', function () {
                var mapOptions = {
                    scrollwheel: false,
                    zoom: 11,
                    center: new google.maps.LatLng(41.079379, 28.9984466) // map coordinates
                };

                map = new google.maps.Map(document.getElementById('map-canvas'),
                        mapOptions);
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(41.0096559, 28.9755535), // marker coordinates
                    map: map,
                    icon: image,
                    title: 'Hello World!'
                });
                marker2 = new google.maps.Marker({
                    position: new google.maps.LatLng(41.007135, 28.910556), // marker coordinates
                    map: map,
                    icon: image,
                    title: 'Hello World!'
                });
                marker3 = new google.maps.Marker({
                    position: new google.maps.LatLng(41.040807, 28.848071), // marker coordinates
                    map: map,
                    icon: image,
                    title: 'Hello World!'
                });
                marker4 = new google.maps.Marker({
                    position: new google.maps.LatLng(41.051164, 32.078097), // marker coordinates
                    map: map,
                    icon: image,
                    title: 'Hello World!'
                });
                marker5 = new google.maps.Marker({
                    position: new google.maps.LatLng(41.077050, 28.995013), // marker coordinates
                    map: map,
                    icon: image,
                    title: 'Hello World!'
                });

                infowindow = new google.maps.InfoWindow({
                    content: contentString
                    , maxWidth: 350
                            //,maxHeight: 500
                });
                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.open(map, marker);
                });
                // more markers
                google.maps.event.addListener(marker2, 'click', function () {
                    infowindow.open(map, marker2);
                });
                google.maps.event.addListener(marker3, 'click', function () {
                    infowindow.open(map, marker3);
                });
                google.maps.event.addListener(marker4, 'click', function () {
                    infowindow.open(map, marker4);
                });
                google.maps.event.addListener(marker5, 'click', function () {
                    infowindow.open(map, marker5);
                });

                // open marker when google map init
                function initialize() {
                    google.maps.event.trigger(marker, 'click');
                }
                initialize();

                /*
                 * The google.maps.event.addListener() event waits for
                 * the creation of the infowindow HTML structure 'domready'
                 * and before the opening of the infowindow defined styles
                 * are applied.
                 */
                google.maps.event.addListener(infowindow, 'domready', function () {

                    // Reference to the DIV which receives the contents of the infowindow using jQuery
                    var iwOuter = $('.gm-style-iw');

                    /* The DIV we want to change is above the .gm-style-iw DIV.
                     * So, we use jQuery and create a iwBackground variable,
                     * and took advantage of the existing reference to .gm-style-iw for the previous DIV with .prev().
                     */
                    var iwBackground = iwOuter.prev();

                    // Remove the background shadow DIV
                    iwBackground.children(':nth-child(2)').css({'display': 'none'});

                    // Remove the white background DIV
                    iwBackground.children(':nth-child(4)').css({'display': 'none'});

                    // Moves the infowindow 115px to the right.
                    iwOuter.parent().parent().css({left: '26px'});

                    // Moves the shadow arrow // hide
                    iwBackground.children(':nth-child(1)').attr('style', function (i, s) {
                        return s + 'display: none !important;'
                    });

                    // Moves the arrow 76px to the left margin
                    iwBackground.children(':nth-child(3)').attr('style', function (i, s) {
                        return s + 'left: 128px !important; margin-top: -10px; z-index: 0;'
                    });

                    // Changes the desired color for the tail outline.
                    // The outline of the tail is composed of two descendants of div which contains the tail.
                    // The .find('div').children() method refers to all the div which are direct descendants of the previous div.
                    iwBackground.children(':nth-child(3)').find('div').children().css({'box-shadow': 'rgba(255, 255, 255, 0.1) 0px 1px 6px', 'z-index': '1'});

                    // Taking advantage of the already established reference to
                    // div .gm-style-iw with iwOuter variable.
                    // You must set a new variable iwCloseBtn.
                    // Using the .next() method of JQuery you reference the following div to .gm-style-iw.
                    // Is this div that groups the close button elements.
                    var iwCloseBtn = iwOuter.next();

                    // Apply the desired effect to the close button
                    iwCloseBtn.css({
                        opacity: '1',
                        right: '48px', top: '14px',
                        width: '19px', height: '19px',
                        border: '3px solid #ffffff',
                        'border-radius': '17px',
                        'background-color': '#ffffff'
                    });

                    // The API automatically applies 0.7 opacity to the button after the mouseout event.
                    // This function reverses this event to the desired value.
                    iwCloseBtn.mouseout(function () {
                        $(this).css({opacity: '1'});
                    });

                });

                //

            });

        }
        //
        if ($('#map-canvas-fs').length) {
            var map;
            var marker, marker2, marker3, marker4, marker5, marker6, marker7, marker8;
            var infowindow;
            var mapIWcontent = '' +
                    '' +
                    // '<div class="map-info-window">' +
                    // '<div class="thumbnail no-border no-padding thumbnail-car-card">' +
                    // '<div class="media">' +
                    // '<a class="media-link" href="#">' +
                    // '<img src="assets/img/preview/cars/car-270x220x1.jpg" alt=""/>' +
                    // '<span class="icon-view"><strong><i class="fa fa-eye"></i></strong></span>' +
                    // '</a>' +
                    // '</div>' +
                    // '<div class="caption text-center">' +
                    // '<h4 class="caption-title"><a href="#">VW POLO TRENDLINE 2.0 TDI</a></h4>' +
                    // '<div class="caption-text">Start from 39$/per a day</div>' +
                    // '<div class="buttons">' +
                    // '<a class="btn btn-theme" href="#">Rent It</a>' +
                    // '</div>' +
                    // '<table class="table">' +
                    // '<tr>' +
                    // '<td><i class="fa fa-car"></i> 2013</td>' +
                    // '<td><i class="fa fa-dashboard"></i> Diesel</td>' +
                    // '<td><i class="fa fa-cog"></i> Auto</td>' +
                    // '</tr>' +
                    // '</table>' +
                    // '</div>' +
                    // '</div>' +
                    // '</div>' +
                    '<div class="r-best-offer-single">'+
                        '<div class="r-best-offer-in">'+
                          '<div class="r-offer-img">'+
                            '<a class="d-inline-block" href="#"><img src="assets/images/best-02.jpg" class="img-fluid d-block m-auto" alt=""></a>'+
                            '<div class="r-offer-img-over">'+
                              '<i class="fa fa-search"></i>'+
                            '</div>'+
                          '</div>'+
                          '<div class="r-best-offer-content">'+
                            '<a href="#"><b>Hyundai</b> Z.E</a>'+
                            '<p>Start at <b>45.00 USD</b> per day</p>'+
                            '<ul class="pl-0 mb-0">'+
                              '<li><i class="fa fa-car"></i><span>2017</span></li>'+
                              '<li><i class="fa fa-cogs"></i><span>MANUAL</span></li>'+
                              '<li><i class="fa fa-beer"></i><span>PETROL</span></li>'+ 
                            '</ul>'+
                          '</div>'+
                          '<div class="r-offer-rewst-this">'+
                            '<span class="text-uppercase">Rent this car</span>'+
                          '</div>'+
                        '</div>'+
                    '</div>'+
                    '';
            var contentString = '' +
                    '' +
                    '<div class="iw-container">' +
                    '<div class="iw-content">' +
                    '' + mapIWcontent +
                    '</div>' +
                    '<div class="iw-bottom-gradient"></div>' +
                    '</div>' +
                    '' +
                    '';
            var image = 'assets/images/icon-google-map.png'; // marker icon
            google.maps.event.addDomListener(window, 'load', function () {
                var mapOptions = {
                    scrollwheel: false,
                    zoom: 11,
                    center: new google.maps.LatLng(41.079379, 28.9984466) // map coordinates
                };

                map = new google.maps.Map(document.getElementById('map-canvas-fs'),
                        mapOptions);
                marker = new google.maps.Marker({
                    position: new google.maps.LatLng(41.0096559, 28.9755535), // marker coordinates
                    map: map,
                    icon: image,
                    title: 'Hello World!'
                });
                marker2 = new google.maps.Marker({
                    position: new google.maps.LatLng(41.007135, 28.910556), // marker coordinates
                    map: map,
                    icon: image,
                    title: 'Hello World!'
                });
                marker3 = new google.maps.Marker({
                    position: new google.maps.LatLng(41.040807, 28.848071), // marker coordinates
                    map: map,
                    icon: image,
                    title: 'Hello World!'
                });
                marker4 = new google.maps.Marker({
                    position: new google.maps.LatLng(41.051164, 29.078097), // marker coordinates
                    map: map,
                    icon: image,
                    title: 'Hello World!'
                });
                marker5 = new google.maps.Marker({
                    position: new google.maps.LatLng(41.077050, 28.995013), // marker coordinates
                    map: map,
                    icon: image,
                    title: 'Hello World!'
                });

                infowindow = new google.maps.InfoWindow({
                    content: contentString
                    , maxWidth: 350
                            //,maxHeight: 500
                });
                google.maps.event.addListener(marker, 'click', function () {
                    infowindow.open(map, marker);
                });
                // more markers
                google.maps.event.addListener(marker2, 'click', function () {
                    infowindow.open(map, marker2);
                });
                google.maps.event.addListener(marker3, 'click', function () {
                    infowindow.open(map, marker3);
                });
                google.maps.event.addListener(marker4, 'click', function () {
                    infowindow.open(map, marker4);
                });
                google.maps.event.addListener(marker5, 'click', function () {
                    infowindow.open(map, marker5);
                });

                // open marker when google map init
                function initialize() {
                    //google.maps.event.trigger(marker, 'click');
                }
                initialize();

                /*
                 * The google.maps.event.addListener() event waits for
                 * the creation of the infowindow HTML structure 'domready'
                 * and before the opening of the infowindow defined styles
                 * are applied.
                 */
                google.maps.event.addListener(infowindow, 'domready', function () {

                    // Reference to the DIV which receives the contents of the infowindow using jQuery
                    var iwOuter = $('.gm-style-iw');

                    /* The DIV we want to change is above the .gm-style-iw DIV.
                     * So, we use jQuery and create a iwBackground variable,
                     * and took advantage of the existing reference to .gm-style-iw for the previous DIV with .prev().
                     */
                    var iwBackground = iwOuter.prev();

                    // Remove the background shadow DIV
                    iwBackground.children(':nth-child(2)').css({'display': 'none'});

                    // Remove the white background DIV
                    iwBackground.children(':nth-child(4)').css({'display': 'none'});

                    // Moves the infowindow 115px to the right.
                    iwOuter.parent().parent().css({left: '26px'});

                    // Moves the shadow arrow // hide
                    iwBackground.children(':nth-child(1)').attr('style', function (i, s) {
                        return s + 'display: none !important;'
                    });

                    // Moves the arrow 76px to the left margin
                    iwBackground.children(':nth-child(3)').attr('style', function (i, s) {
                        return s + 'left: 128px !important; margin-top: -10px; z-index: 0;'
                    });

                    // Changes the desired color for the tail outline.
                    // The outline of the tail is composed of two descendants of div which contains the tail.
                    // The .find('div').children() method refers to all the div which are direct descendants of the previous div.
                    iwBackground.children(':nth-child(3)').find('div').children().css({'box-shadow': 'rgba(255, 255, 255, 0.1) 0px 1px 6px', 'z-index': '1'});

                    // Taking advantage of the already established reference to
                    // div .gm-style-iw with iwOuter variable.
                    // You must set a new variable iwCloseBtn.
                    // Using the .next() method of JQuery you reference the following div to .gm-style-iw.
                    // Is this div that groups the close button elements.
                    var iwCloseBtn = iwOuter.next();

                    // Apply the desired effect to the close button
                    iwCloseBtn.css({
                        opacity: '1',
                        right: '48px', top: '14px',
                        width: '19px', height: '19px',
                        border: '3px solid #ffffff',
                        'border-radius': '17px',
                        'background-color': '#ffffff'
                    });

                    // The API automatically applies 0.7 opacity to the button after the mouseout event.
                    // This function reverses this event to the desired value.
                    iwCloseBtn.mouseout(function () {
                        $(this).css({opacity: '1'});
                    });

                });

                //

            });

        }
    }
    });