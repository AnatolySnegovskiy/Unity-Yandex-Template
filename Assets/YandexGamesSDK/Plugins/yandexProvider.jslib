mergeInto(LibraryManager.library, {
  Quit: function () {
    quit();
  },
  
  InitPurchases: function() {
    initPayments();
  },

  Purchase: function(id) {
    buy(id);
  },

  AuthenticateUser: function() {
    auth();
  },

  GetUserData: function() {
    getUserData();
  },

  ShowFullscreenAd: function () {
    showFullscrenAd();
  },

  ShowRewardedAd: function(placement) {
    showRewardedAd(placement);
    return placement;
  },
  
  SaveData: function(data) {
    saveData(data);
  },
  
  LoadData: function(data) {
    loadData();
  },
  
  StartYa: function() {
    startYa();
  },
  
  OpenWindow: function(link){
    var url = Pointer_stringify(link);
      document.onmouseup = function()
      {
        window.open(url);
        document.onmouseup = null;
      }
  }
});