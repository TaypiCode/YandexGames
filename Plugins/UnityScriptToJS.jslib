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
   Purchase: function(item_id){
    // Convert bytes to the text
    var convertedText = Pointer_stringify(placement);
    // Pass message to the page
    PurchaseFromUnity(convertedText); //call js func
   }
});