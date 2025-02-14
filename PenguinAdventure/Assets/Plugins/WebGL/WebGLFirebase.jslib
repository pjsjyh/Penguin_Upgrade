mergeInto(LibraryManager.library, {
    // ✅ 점수 저장 함수
    SaveScoreToFirebase: function(usernamePtr, score) {
        var username = UTF8ToString(usernamePtr);
        console.log("🔥 WebGL: Firebase 점수 저장 요청 -> " + username + ": " + score);

        if (typeof window.firebaseDatabase === "undefined") {
            console.error("❌ Firebase가 정의되지 않음! SDK 로드 확인 필요");
            return;
        }

        // ✅ Firebase Realtime Database에 데이터 저장
        var databaseRef = window.firebaseRef(window.firebaseDatabase, "rankings");
        window.firebasePush(databaseRef, { username, score })
            .then(() => console.log("✅ Score saved:", { username, score }))
            .catch(error => console.error("❌ Error saving score:", error));
    },

    // ✅ 랭킹 데이터 불러오는 함수 (정렬 포함)
    LoadRankingsFromFirebase: function() {
        console.log("🔥 WebGL: 랭킹 불러오기 요청됨!");

        if (typeof window.firebaseDatabase === "undefined") {
            console.error("❌ Firebase가 정의되지 않음! SDK 로드 확인 필요");
            return;
        }

        var databaseRef = window.firebaseRef(window.firebaseDatabase, "rankings");

        // ✅ 데이터 가져오기
        window.firebaseGet(databaseRef)
            .then(snapshot => {
                var rankings = [];
                snapshot.forEach(childSnapshot => {
                    rankings.push(childSnapshot.val());
                });

                // ✅ 점수 기준 내림차순 정렬 (높은 점수 → 낮은 점수)
                rankings.sort((a, b) => b.score - a.score);

                // ✅ 상위 10개만 유지
                rankings = rankings.slice(0, 10);

                console.log("✅ Firebase 랭킹 불러오기 완료:", rankings);

                // ✅ Unity WebGL로 데이터 전달
                setTimeout(() => {
                    if (typeof unityInstance !== "undefined") {
                        unityInstance.SendMessage("RankingPanel", "OnRankingsLoaded", JSON.stringify(rankings));
                    } else {
                        console.error("❌ Unity 인스턴스가 정의되지 않음!");
                    }
                }, 1000);
            })
            .catch(error => console.error("❌ Firebase 랭킹 불러오기 실패:", error));
    }
});
