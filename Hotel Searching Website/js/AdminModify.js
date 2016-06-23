$(document).ready(function(){
	var $ExistFlag = false;
	var $ServerUrl = 'Server-Side.php';

	/*
	* Event : onblur for id=userName (button)
	* Description : it is used to check user name whether is exist when user login.
	*/
	$('#userName').bind('blur', function(){
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
				AddUserName: $('#userName').val()
			},
			success: function(responseText){
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
	* Event : onblur for id=modifyBut (button)
	* Description : it is used to check user name whether is exist when user modify.
	*/
	$('#modifyBut').click(function(){
		if($ExistFlag == true)
		{
			$('#error2').css({
				color: 'red'
			});
			$('#error2').html("Please choose another name(This User Name has exist).");
			return false;
		}


		$.ajax({
			url: $ServerUrl,
			type: 'POST',
			dataType: 'TEXT',
			data: {
				modify: $('#UserID').val(),
				name: $('#userName').val(),
				level: $('#securityLevel').val()
			},
		})
		.done(function(responseText) {

			if (responseText == "Modify Successfully") {
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
	});
});