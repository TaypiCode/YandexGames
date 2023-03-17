mergeInto(LibraryManager.library, {
   ShowInterstitialAd: function() {
    // Pass message to the page
    ShowInterstitialAdFromUnity(); //call js func
   },
   ShowRewardAd: function (placement) {
    // Convert bytes to the text
    var convertedText = Pointer_stringify(placement);
    // Pass message to the page
    ShowRewardAdFromUnity(convertedText); //call js func
   },
   SetLeaderboardData: function (leaderboardName, leaderboardValue){
    // Convert bytes to the text
    var convertedText = Pointer_stringify(leaderboardName);
    // Pass message to the page
    var value = parseFloat(leaderboardValue);
    SetLeaderboardDataFromUnity(convertedText, value); //call js func
   },	
   Purchase: function(item_id){
    // Convert bytes to the text
    var convertedText = Pointer_stringify(placement);
    // Pass message to the page
    PurchaseFromUnity(convertedText); //call js func
   },
   RateUs: function() {
	ShowRateUs(); //js function
   },
   SaveData: function(data)
   {
    var convertedText = Pointer_stringify(data);
    SaveDataFromUnity(convertedText); //call js func
   },
   FirstLoadInSession: function()
   {
    FirstLoadInSessionFromUnity(); //call js func
   }
});