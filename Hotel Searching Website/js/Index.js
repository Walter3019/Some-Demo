$(document).ready(function() {
	var $ExistFlag = false; // flag for UserName exist.
	var $ServerUrl = 'Server-Side.php'; // server Url.

	// instance a bloodhound object to get result from City.php file.
	var cities = new Bloodhound({
		datumTokenizer: Bloodhound.tokenizers.obj.whitespace('City'),
		queryTokenizer: Bloodhound.tokenizers.whitespace,
		remote: { 
			url: 'City.php?query=%QUERY', 
			wildcard: '%QUERY' 
		} 
	});
	
	// initialize bloodhound.
	cities.initialize();
	
	// using typeahead to make auto complete enter information.
	$('#City').typeahead({
			hint:true,
			highlight: true,
		},{
			name: 'City',
			displayKey: 'City',
			source: cities.ttAdapter()
	});





	/*
	* Event : onblur for id=userName (button)  
	* Description : it is used to check user name whether is exist when user login.
	*/
	$('#userName').on("blur", function(){

		// clear old error message.
		$('#error1').html('');

		// 
		$.ajax({
			url: $ServerUrl,
			type: 'POST',
			dataType: 'TEXT',
			data: {
				'checkUser': '1',
				'userName':  $('#userName').val()
			},
			success: function(responseText){
				// set red color for responseText.
				$('#error1').css({
					color: 'red'
				});
				$('#error1').html(responseText);			
			}
		});
	});





	/*
	* Event : onblur for id=AddUserName (button)  
	* Description : it is used to check user name whether is exist when user add a new user.
	*/
	$('#AddUserName').bind('blur', function(){
		//
		$ExistFlag = false;

		//
		$('#error2').html('');

		$.ajax({
			url: $ServerUrl,
			type: 'POST',
			dataType: 'TEXT',
			data: {
				Exist: '1',
				AddUserName: $('#AddUserName').val()
			},
			success: function(responseText){
				console.log(responseText);
				if (responseText == 'The user name can Use.') {
					$('#error2').css({
						color: 'green'
					});
					$('#error2').html(responseText);
				}
				else{
					$('#error2').css({
						color: 'red'
					});
					$('#error2').html(responseText);
					$ExistFlag = true;
				}
			}
		})
		
	});





	/*
	* Event : onclick for id=loginBut (button) 
	* Description : it is used to login website.
	*/
	$('#loginBut').click(function(event) {
		if (true == check_Sumbit("login")) ajaxLogin();
	});

 
	/*
	* Event : onclick for id=registerBut (button)
	* Description : it is used to register a new user.
	*/
	$('#registerBut').click(function(){
		if ($ExistFlag == true) {
			$('#error2').css({
				color: 'red'
			});
			$('#error2').html("Please choose another name(This User Name has exist).");
			return false;
		}

		if (true == check_Sumbit("")) ajaxAddUser();
	});




	/*
	* Function : check_Sumbit()
	* Description : this function is used to check user name and password when user submit.
	* Parameter : Nothing
	* Return : Nothing
	*/
	function check_Sumbit(type){
		var $userName;
		var $pwd;
		var $error;

		if (type == "login") {
			$userName = $('#userName').val();
			$pwd = $('#pwd').val();
		}
		else{
			$userName = $('#AddUserName').val();
			$pwd = $('#addPwd').val();
		}

		if ($userName == "" || $pwd == "") {
			$error = 'User name and passwrod can not be blank.';
			if (type == "login") {
				$('#error1').css({
					color: 'red'
				});
				$('#error1').html($error);
			}else{
				$('#error2').css({
					color: 'red'
				});
				$('#error2').html($error);
			}

			return false;
		}

		return true;
	}





	/*
	* Function : ajaxLogin()
	* Description : this function is used to login by user.
	* Parameter : Nothing
	* Return : Nothing
	*/
	function ajaxLogin(){
		$.ajax({
			url: $ServerUrl,
			type: 'POST',
			dataType: 'TEXT',
			data: {
				login: '1',
				UserName: $('#userName').val(),
				pwd: $('#pwd').val()
			}
		})
		.done(function(responseText) {
			if (responseText == 'Successfully') {
				$('#error1').css({
					color: 'green'
				});
				$('#error1').html(responseText);
				setTimeout('location.reload()', 1000);
			}
			else{
				$('#error1').html(responseText);
			}

		});
			
	}




	/*
	* Function : ajaxAddUser()
	* Description : this function is used to add a new user into database by AJAX.
	* Parameter : Nothing
	* Return : Nothing
	*/
	function ajaxAddUser(){
		$.ajax({
			url: $ServerUrl,
			type: 'POST',
			dataType: 'TEXT',
			data: {
				add: '1',
				AddUserName: $('#AddUserName').val(),
				addPwd: $('#addPwd').val(),
				captcha: $('#captcha').val()
			},
		})
		.done(function(responseText) {
			// check result 
			if (responseText == 'Successfully') {
				$('#error2').css({
					color: 'green'
				});
				$('#error2').html(responseText);
				setTimeout('location.reload()', 1000);
			}
			else{
				$('#error2').css({
					color: 'red'
				});
				$('#error2').html(responseText);
			}
		});
		
	}







	/*
	* Event : onclick for id=logoutBut (button)
	* Description : it is used to clear session when user log-out.
	*/
	$('#logoutBut').click(function(){
		$.ajax({
			url: $ServerUrl,
			type: 'POST',
			data: {
				logout: '1'
			},
		})
		.done(function() {
			location.reload();
		});		
	});
});




