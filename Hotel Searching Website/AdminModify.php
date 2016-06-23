<?php
	// include PDOHelper.php file.
	include_once 'classes/PDOHelper.class.php';
	// open sesiion.
	session_start();

	$page = isset($_GET['page']) ? $_GET['page'] : 1;

	$isLogin = ""; // set flag for login.
	//$usename = $_SESSION["username"];
	
	// each page hold 5 records.
	$pagecount = 5;

	
	// using PDOHelper to connect database.
	$pdo = new PDOHelper(array('charset' => 'utf8'));
	
	$sql = "SELECT User_ID, User_Name, s.SecurityDescription FROM Users u INNER JOIN securityLevel s ON u.SecurityLevel_ID = s.SecurityLevel_ID having User_ID";
	$res = $pdo->getAll($sql);
		
	//get total records.
	$count = count($res);

	// calculate how many pages.
	$pages = ceil($count / $pagecount);

	if($page < 1) $page = 1;
	if($page > $pages) $page = $pages;
	

	// get position of page.
	$offset = ($page - 1) * $pagecount;

	// get each page records.
	$sql = $sql . " limit {$offset},{$pagecount}";
	$res = $pdo->getAll($sql);
?>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head>
	<!--<meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
	<title>List of Hotel</title>
	<link rel="stylesheet" type="text/css" href="" />
	<style type="text/css"></style>
	<script type="text/javascript" language="javascript"></script>-->
	
	
	
	<meta charset="utf-8">
	<title>List of User</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, 
                                     initial-scale=1.0, 
                                     maximum-scale=1.0, 
                                     user-scalable=no">



    <!-- Bootstrap -->
	<!-- Latest compiled and minified CSS -->
	<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">

	<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
	<!-- Latest compiled JavaScript -->
	<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>

	<script type="text/JavaScript">

		/*
    	* Function : ModifyHelper()
    	* Description : This function is used to set info to modal dialog
    	* Parameter : user id, user security level, user name
    	* Return : Nothing
    	*/
		function ModifyHelper(id, level, name){
			userName.value = name;
			
			if(level == "General"){
				securityLevel.value = 1;
			}
			else if(level == "Admin"){
				securityLevel.value = 2;
			}
			
			UserID.value = id;
			
			$('#divModify').modal('show');
		}

		function Delete(id){
			$.ajax({
				url: 'Server-Side.php',
				dataType: 'POST',
				data: {
					delete: id
				},
			})
			.done(function() {
				setTimeout('location.reload()', 1000);
			});
		}
	</script>



</head>
  <body style='background-image: url("./img/background.jpg")'>
	<!-- Header -->
	<nav class="navbar navbar-inverse">
	  <div class="container-fluid">
		<div class="navbar-header">
		  <a class="navbar-brand" href="index.php">Hotel Info</a>
		</div>
		<ul class="nav navbar-nav navbar-right">
		   <li class="active"><a href="index.php">Home</a></li>
		   <li class="active"><a href="#">About</a></li>
		   
		   <li><a href="index.php"><span class="glyphicon glyphicon-user"></span><?php echo $_SESSION["username"];?></a></li>
		   
			<?php if($isLogin == false){?>
		   <li><a href="index.php"><span class="glyphicon glyphicon-log-in"></span>Go Back</a></li>
		   <?php }
		   else
		   {
			   echo "<li><a href='#' onclick='ajaxLogOut()'><span class='glyphicon glyphicon-log-out'></span> Log Out</a></li>";
		   }?>
		</ul>
	  </div>
	</nav>


	<div class="contrain">
	<div class="row">
	<div class="col-md-2"></div>
	<div class="col-md-8">
		<form>
		<table class="table table-hover text-center">
			<tr class="active">
				<th class="text-center">Id</th>
				<th class="success text-center">User Name</th>
				<th class="text-center">User Type</th>
				<th class="success text-center">User Modify</th>
				<th class="text-center">User Delete</th>
			</tr>
			<?php foreach($res as $Users):?>
			<tr class="active">
				<td class="active"><?php echo $Users['User_ID'];?></td>
				<td class="success"><?php echo $Users['User_Name'];?></td>
				<td><?php echo $Users['SecurityDescription'];?></td>
				<td class="success">
					<input type="button" name="modify" onclick="ModifyHelper(<?php echo $Users['User_ID'];?>, '<?php echo $Users['SecurityDescription'];?>', '<?php echo $Users['User_Name'];?>')" value="Modify"></input>
				</td>
				<td><input type="button" name="delete" onclick="Delete(<?php echo $Users['User_ID'];?>)" value="Delete"></input></td>
			</tr>
			<?php endforeach;?>
		</table>
		</form>
	</div>
	</div>
	</div>
		<div class="contrain"><div class="col-md-3"></div><div class="col-md-8">Have <?php echo $count;?> Records,Each page display <?php echo $pagecount;?> record,Total <?php echo $pages;?> Page <?php echo $page;?> Page,<a href="adminModify.php?page=<?php echo ($page == 1) ? $page : $page-1;?>" >Last Page</a>,<a href="adminModify.php?page=<?php echo ($page == $pages) ? $pages : ($page + 1);?>">Next Page</a></div></div>
	</div>
	
		<!-- login modal-dialog -->
	<div id="divModify" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header">
					<button type="button" class="close" data-toggle="modal" data-target="#divModify">x</button>
					<h1 class="text-center text-primary">Modify</h1>
				</div>
				<div class="modal-body">
					<!-- Form -->
					<form name="loginForm" method = "post" class="form col-md-12 center-block" />
						<div class="form-group">
							<input type="text" id="UserID" name="UserID" class="form-control input-lg" DISABLED>
						</div>
						
						<div class="form-group">
							<input type="text" id="userName" name="UserName" class="form-control input-lg" placeholder="Please Enter User Name" onblur="ajaxCheckUserExist()">
						</div>
						
						<div class="form-group">
							<select class="form-control" id="securityLevel"> 
							<option value="1">General</option> 
							<option value="2">Admin</option> 
							</select>
						</div>						
						<div class="form-group">
							<input type="button" id="modifyBut" class="btn btn-primary btn-lg btn-block" value="Modify It">
						</div>
							
						<!-- error message -->
						<span id="error2"></span>
					</form>
				</div>
				<div class="modal-footer"></div>
			</div>
		</div>
	</div>
	
		<!-- footer -->
  <div class="navbar navbar-inverse navbar-fixed-bottom">
	<div class="contrainer">
		<p class="navbar-text">Site Built By vavaqw</p>	
	<div>
  </div>

		<script src="js/AdminModify.js" type="text/javascript"></script>
		
	<script type="text/javascript">

	/*
	* Function : ModifyHelper()
	* Description : This function is used to set info to modal dialog
	* Parameter : user id, user security level, user name
	* Return : Nothing
	*/
	function ModifyHelper(id, level, name){
		userName.value = name;
		
		if(level == "General"){
			securityLevel.value = 1;
		}
		else if(level == "Admin"){
			securityLevel.value = 2;
		}
		
		UserID.value = id;
		
		$('#divModify').modal('toggle');
	}


	function Delete(id){
		$.ajax({
			url: 'Server-Side.php',
			type: 'POST',
			data: {
				delete: id
			},
		})
		.done(function() {
			setTimeout('location.reload()', 1000);
		});
	}
	</script>
</body>
</html>