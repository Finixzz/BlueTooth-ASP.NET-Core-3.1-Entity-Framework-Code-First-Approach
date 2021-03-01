$(document).ready(function () {
    function prebrojiRecenzije() {
        prebroji(0, 0, 0);
    }

    function spremiRazliku(razlika) {
        let diff;
        if (localStorage.getItem("diff") == null) {
            diff = 0;
        } else {
            diff = parseInt(JSON.parse(localStorage.getItem("diff")));
        }
        diff += razlika;
        localStorage.setItem("diff", JSON.stringify(diff));
        return diff;
    }


    function prebroji(recenzijeCount, time, br) {
        br == 0 ? time = 1 : time = 3000;
        br++;
        $.ajax({
            method: "GET",
            url: "/api/GetAllRatingInfo",
            dataType: "json",
            data: "[]",
            success: function (ratings) {
                recenzijeCount = ratings.length;
                setTimeout(function () {
                    $.ajax({
                        method: "GET",
                        url: "/api/GetAllRatingInfo",
                        dataType: "json",
                        data: "[]",
                        success: function (ratingsUpdate) {
                            let razlikaSession = spremiRazliku(ratingsUpdate.length - recenzijeCount);

                            if (razlikaSession != 0) {
                                let razlikaSession = spremiRazliku(ratingsUpdate.length - recenzijeCount);
                                $("#divNotifikacija").css("display", "block");
                                $("#manage").css("border-bottom", "5px solid #d9534f");
                                $("#notifikacija").text(razlikaSession / 2);
                            } else {
                                $("#divNotifikacija").css("display", "none");
                                $("#notifikacija").text("");
                                $("#manage").css("border-bottom", "none");
                            }
                            $("#recenzijeAkcija").on("click", () => {
                                localStorage.removeItem("diff");
                            })
                            prebroji(0, 0, br);
                        }
                    });
                }, time);
            }
        });
    }

    prebrojiRecenzije();
})

