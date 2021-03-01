﻿$(document).ready(function () {
    function prebrojiFakture() {
        prebroji(0, 0, 0);
    }

    function spremiRazliku(razlika) {
        let diffFakture;
        if (localStorage.getItem("diffFakture") == null) {
            diffFakture = 0;
        } else {
            diffFakture = parseInt(JSON.parse(localStorage.getItem("diffFakture")));
        }
        diffFakture += razlika;
        localStorage.setItem("diffFakture", JSON.stringify(diffFakture));
        return diffFakture;
    }

    function ocistiSkladiste() {
        localStorage.clear();
    }
    function prebroji(recenzijeCount, time, br) {
        br == 0 ? time = 1 : time = 3000;
        br++;
        $.ajax({
            method: "GET",
            url: "/api/dentalchecks",
            dataType: "json",
            data: "[]",
            success: function (ratings) {
                recenzijeCount = ratings.length;
                setTimeout(function () {
                    $.ajax({
                        method: "GET",
                        url: "/api/dentalchecks",
                        dataType: "json",
                        data: "[]",
                        success: function (ratingsUpdate) {
                            let razlikaSession = spremiRazliku(ratingsUpdate.length - recenzijeCount);

                            if (razlikaSession != 0) {
                                let razlikaSession = spremiRazliku(ratingsUpdate.length - recenzijeCount);
                                $("#divNotifikacijaFakture").css("display", "block");
                                $("#manageFakture").css("border-bottom", "5px solid #d9534f");
                                $("#notifikacijaFakture").text(razlikaSession / 2);
                            } else {
                                $("#divNotifikacijaFakture").css("display", "none");
                                $("#notifikacijaFakture").text("");
                                $("#manageFakture").css("border-bottom", "none");
                            }
                            $("#faktureAkcija").on("click", () => {
                                localStorage.removeItem("diffFakture");
                            });
                            prebroji(0, 0, br);
                        }
                    });
                }, time);
            }
        });
    }

    prebrojiFakture();
})

