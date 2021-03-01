$(document).ready(function () {
    function prebrojiFaktureVlasnik() {
        prebroji(0, 0, 0);
    }

    function spremiRazliku(razlika) {
        let diffFaktureVlasnik;
        if (localStorage.getItem("diffFaktureVlasnik") == null) {
            diffFaktureVlasnik = 0;
        } else {
            diffFaktureVlasnik = parseInt(JSON.parse(localStorage.getItem("diffFaktureVlasnik")));
        }
        diffFaktureVlasnik += razlika;
        localStorage.setItem("diffFaktureVlasnik", JSON.stringify(diffFaktureVlasnik));
        return diffFaktureVlasnik;
    }


    function prebroji(recenzijeCount, time, br) {
        br == 0 ? time = 1 : time = 3000;
        br++;
        $.ajax({
            method: "GET",
            url: "/api/bills",
            dataType: "json",
            data: "[]",
            success: function (ratings) {
                recenzijeCount = ratings.length;
                setTimeout(function () {
                    $.ajax({
                        method: "GET",
                        url: "/api/bills",
                        dataType: "json",
                        data: "[]",
                        success: function (ratingsUpdate) {
                            let razlikaSession = spremiRazliku(ratingsUpdate.length - recenzijeCount);

                            if (razlikaSession != 0) {
                                let razlikaSession = spremiRazliku(ratingsUpdate.length - recenzijeCount);
                                $("#divNotifikacijaFaktureVlasnik").css("display", "block");
                                $("#manage").css("border-bottom", "5px solid #d9534f");
                                $("#notifikacijaFaktureVlasnik").text(razlikaSession / 2);
                            } else {
                                $("#divNotifikacijaFaktureVlasnik").css("display", "none");
                                $("#notifikacijaFaktureVlasnik").text("");
                                $("#manage").css("border-bottom", "none");
                            }
                            $("#faktureAkcijaVlasnik").on("click", () => {
                                localStorage.removeItem("diffFaktureVlasnik");
                            });
                            prebroji(0, 0, br);
                        }
                    });
                }, time);
            }
        });
    }

    prebrojiFaktureVlasnik();
})

