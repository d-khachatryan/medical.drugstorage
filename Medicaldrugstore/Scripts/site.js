//For Navigation Menu Hover Dropdown Function
//$('ul.nav li.dropdown').hover(function ()
//    {
//        $(this).find('.multi-level').stop(true, true).delay(100).fadeIn(300);
//    }, function ()
//    {
//        $(this).find('.multi-level').stop(true, true).delay(100).fadeOut(500);
//    });


// document.ready
$(document)
    .ready(function () {
        //Grid height
        var gridHeight =
            $(window).height() - $(".nav_menu ").height() - $(".toolbar").height() -60;
        $(".k-grid").height(gridHeight);
        $(".report").height($(window).height() - $(".nav_menu ").height() - $(".toolbar").height()-30);
        $("#DrugClass, #Drug").height(gridHeight - $("ul.k-tabstrip-items").height());
        $("#MessageBox, #MessageBox-Right").height(gridHeight - 53);
        $("#SentMessageBox, #SentMessageBox-Right").height(gridHeight - 10);
        //$("#MessageBox-Right .k-grid-content").height($("#MessageBox .k-grid-content").height());
        //$(".messageText").height($("#MessageBox").height() - 44);
        //var rowsQuant = ($("#MessageBox-Right").height() - $("#MessageBox-Right .k-grid-pager").height() -25) / 20;
        //$(".message-box textarea").attr("rows", rowsQuant)



        //For Right Slide
        var next_move = "closed";
        $(".right-slidePanel .slidePanel-btn").html("<i class=\"glyphicon glyphicon-search\"></i>");
        $(".right-slidePanel .slidePanel-btn, .right-slidePanel #rtSearch")
                .click(function () {
                    console.log(next_move);
                    var css = {};
                    if (next_move == "closed") {
                        css = {
                            right: '0'
                        };
                        $(".right-slidePanel .slidePanel-btn").html("<i class=\"glyphicon glyphicon-chevron-right\"></i>");
                        next_move = "shrink";
                    } else {
                        css = {
                            right: '-300px'
                        };
                        console.log('hi');
                        next_move = "closed";
                        $(".right-slidePanel .slidePanel-btn").html("<i class=\"glyphicon glyphicon-search\"></i>");
                    }
                    $(this).closest(".right-slidePanel").animate(css, 200);
                });
        $(".right-slidePanel .slidePanel-Content-fields").css('max-height', $(".k-grid").height() + 30);

        //Search Accordeon
        //$(".accordion").click(function () {
        //    $(this).toggleClass("active");
        //    $(this).next("div").toggleClass("show");
        //});

        //Toolbar fixing top
        //$(window)
        //    .scroll(function () {
        //        var fixmeTop = $('.toolbar').position().top;
        //        var currentScroll = $(window).scrollTop();
        //        if (currentScroll >= fixmeTop - 52) {
        //            $('.toolbar-fixed')
        //                .css({
        //                    'display': "block",
        //                    'position': 'fixed',
        //                    'top': '50px',
        //                    'z-index': '100'
        //                });
        //        } else {
        //            $('.toolbar-fixed')
        //                .css({
        //                    "display": "none"
        //                });
        //        }
        //    });
    });

    //For Grid Commands Icons
        function onRowBound(e) {
            $(".k-grid-Update, .Update_Icon").find("span").addClass("glyphicon glyphicon-pencil");
            $(".k-grid-Delete, .Delete_Icon").find("span").addClass("glyphicon glyphicon-trash");
            $(".Attache_Icon").find("span").addClass("glyphicon glyphicon-paperclip");
        }


        function showCommandIcons() {
            $(".Update_Icon").find("span").addClass("glyphicon glyphicon-pencil");
            $(".Delete_Icon").find("span").addClass("glyphicon glyphicon-trash");
            $(".Remove_Icon").find("span").addClass("glyphicon glyphicon-remove");
            //$(".Attache_Icon").find("span").addClass("glyphicon glyphicon-paperclip");
            $(".Show_Icon").find("a").addClass("k-button k-button-icontext")
            $(".Show_Icon").find("a").html("<span class='glyphicon glyphicon-picture'></span>");
        }

        