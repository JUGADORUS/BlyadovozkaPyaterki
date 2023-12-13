mergeInto(LibraryManager.library, {
	
	Hello: function () {
		window.alert("Hello, world!");
		console.log("Hello, world!");
	},

	ShowFullscreenAdv: function () {
		ysdk.adv.showFullscreenAdv({
		callbacks: {
				onClose: function(wasShown) {
				  // some action after close
				},
				onError: function(error) {
				  // some action on error
				}
			}
		})
	},

	GetLanguage: function() {
		if(!ysdk) return;
		var returnStr = ysdk.environment.i18n.lang;
		var bufferSize = lengthBytesUTF8(returnStr) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(returnStr, buffer, bufferSize);
		return buffer;
	},
	SetLeaderBoard: function(score){
		var player;
		ysdk.getPlayer().then(_player => {
			player = _player;
		}).catch(err => {
		});

		var lb;
		ysdk.getLeaderboards()
		.then(lb => {
			lb.setLeaderboardScore('TimeLiving', score, player.getName());

		})
	}
});