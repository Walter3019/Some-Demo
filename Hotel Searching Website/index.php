<?php 
	// include PDOHelper class from another php file.
    include ("classes/PDOHelper.class.php"); 
	
	// open session
	session_start();
	
	// Clear hotel Name Info in session.
	$_SESSION["HotelName"]  = "";
	// Clear City Name Info in session.
	$_SESSION["City"]  = "";
	
	// initiate error message.
	$error_msg ="";
	// initiate username.
	$name="";
	// initiate isLogin flag.
	$isLogin = false;
	
	// check whether a user login.
	if(isset($_SESSION['user_id'])){
		if(isset($_SESSION['SecurityLevel'])){
			if($_SESSION['SecurityLevel'] == ""){
				$name="";
				$isLogin = false;
			}
			else if($_SESSION['SecurityLevel'] == "1"){
				$isLogin = true;
				$name = $_SESSION['username'];
			}
			else if($_SESSION['SecurityLevel'] == "2"){
				$isLogin = true;
				$name = $_SESSION['username'];
			}
		}else{
			$isLogin = false;
		}
	}
	else{ // otherwise.
		$isLogin = false;
	}
?>


<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, 
                                     initial-scale=1.0, 
                                     maximum-scale=1.0, 
                                     user-scalable=no">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>Hotel Search Web</title>

    <!-- Bootstrap -->
	<!-- Latest compiled and minified CSS -->
	<link rel="stylesheet" href="css/bootstrap.min.css">
	<script src="js/jQuery 2.2.4.min.js"></script>
	<!-- Latest compiled JavaScript -->
	<script src="js/bootstrap.min.js"></script>
		
	<link rel="stylesheet" type="text/css" href="css/normalize.css" />
	<link rel="stylesheet" type="text/css" href="css/demo.css" />
	<link rel="stylesheet" type="text/css" href="css/component.css" />
	<link rel="stylesheet" type="text/css" href="css/demo1.css" />
	
  </head>
  <body style="background: url('./img/background.jpg') no-repeat fixed center">
	<!-- Navigation bar -->
	<nav class="navbar navbar-inverse">
	  <div class="container-fluid">
		<div class="navbar-header">
		  <a class="navbar-brand" href="index.php">Hotel Info</a>
		</div>
		<ul class="nav navbar-nav navbar-right">
		   <li class="active"><a href="index.php">Home</a></li>
		   <li class="active"><a href="#">About</a></li>
		   	<?php if($isLogin == false){?>
		   <li><a href="#" data-toggle="modal" data-target="#register"><span class="glyphicon glyphicon-user"></span> Register</a></li>
		   <?php }
		   else
		   {
			   if($_SESSION['SecurityLevel'] == 2){
				   echo "<li><a class='dropdown-toggle active' data-toggle='dropdown' href='#'>{$_SESSION['username']}
						<span class='caret'></span></a>
						<ul class='dropdown-menu'>
						  <li><a href='AdminModify.php'>Management User</a></li>
						</ul>
					  </li>";
			   }
			   else{
				   echo "<li><a href='#'><span class='glyphicon glyphicon-user'></span>{$_SESSION['username']}</a></li>";
			   }
			   
			   

			   
		   }?>
		   
			<?php if($isLogin == false){?>
		   <li><a href="#" data-toggle="modal" data-target="#divLogin"><span class="glyphicon glyphicon-log-in"></span>Sign In</a></li>
		   <?php }
		   else
		   {
			   echo "<li><a href='#' id='logoutBut'><span class='glyphicon glyphicon-log-out'></span> Log Out</a></li>";
		   }?>
		</ul>
	  </div>
	</nav>

	<!-- login modal-dialog -->
	<div id="divLogin" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header">
					<button type="button" class="close" data-toggle="modal" data-target="#divLogin">x</button>
					<h1 class="text-center text-primary">Login</h1>
				</div>
				<div class="modal-body">
					<!-- Form -->
					<form name="loginForm" method = "post" class="form col-md-12 center-block" action="index.php" >
						<div class="form-group">
							<input type="text" id="userName" name="UserName" class="form-control input-lg" placeholder="Please Enter User Name">
						</div>
						
						<div class="form-group">
							<input type="password" id="pwd" name="Pwd" class="form-control input-lg" placeholder="Login Password">
						</div>
						
						<div class="form-group">
							<input type="button" id ="loginBut" class="btn btn-primary btn-lg btn-block" name="submit" value="Log In">
						</div>
							
						<!-- error message -->
						<span id="error1"></span>
						<span id="error3"><?php echo $name;?></span>
					</form>
				</div>
				<div class="modal-footer"></div>
			</div>
		</div>
	</div>

	<!-- register modal-dialog -->
	<div id="register" class="modal fade">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header">
					<button type="button" class="close" data-toggle="modal" data-target="#register">x</button>
					<h1 class="text-center text-primary">Register</h1>
				</div>
				<div class="modal-body">
					<!-- Form -->
					<form name="registerForm" class="form col-md-12 center-block" action="index.php" onsubmit="return ajaxAddUser()">
						<div class="form-group">
							<input type="text" id="AddUserName" class="form-control input-lg" placeholder="Please Enter new User Name" />
						</div>
						
						<div class="form-group">
							<input type="password" id="addPwd" class="form-control input-lg" placeholder="Login Password">
						</div>
						
						<div class="form-group">
							<img src="Server-Side.php?act=1" alt="CAPTCHA" style="cursor: pointer;" title="See? Click to replace another Captcha." onClick="this.src = 'Server-Side.php?act=1&time='+Math.random()"/>
							<input type="text" id="captcha" name="captcha">
						</div>
						
						<div class="form-group">
							<input type="button" id="registerBut" class="btn btn-primary btn-lg btn-block" name="addsubmit" value="Register">
						</div>
						
						<!-- error message -->
						<span id="error2"></span>
					</form>
				</div>
				<div class="modal-footer"></div>
			</div>
		</div>
	</div>


	<!-- Searching Hotel Info-->
	<div class="contrain">     
        <div class="row"> 
			<div class="col-md-1"></div> 
			<div class="col-md-4">
			<div class="col-sm-17">
				<div class="panel" style="background: url('./img/panel-b.jpg') no-repeat;background-size: cover">
					<!-- Title -->
					<div class="panel-heading"> 
						<h3 class="panel-title" style="color: #2e5d5a"><strong>Inquire Hotel</strong></h3> 
					</div>
					
					<!-- get hotel Info -->
					<div class="panel-body flex-grow"> 
						<!-- Form -->
						<form role="form" class="form center-block" name="form1" action="list.php" method="POST" autocomplete="off"> 
							<!-- get Hotel name info-->
							<div class="form-group"> 
								<label for="HotelName"><h4>Hotel Name</h4></label> 
								<div class="input-group"> 
									<input type="text" class="form-control" id="HotelName" name="HotelName" placeholder="Hotel Name" />
								</div> 
							</div> 
							<!-- get City name info-->
							<div class="form-group"> 
								<label for="Checkout"><h4>City</h4></label> 
								<div class="input-group"> 
									<input type="text" class="form-control" data-provide="typeahead" id="City" name="City" placeholder="City" /> 								   
							   </div>
							</div> 
							</br>
							</br>
							<span class="input-group-btn"> 
								<div class="text-center">
								<!-- searching button -->
									<button type="submit" class="btn" onClick="form1.submit();" name="HotelSearch">Search</button> 
								</div>
							</span> 
					   </form>  
					</div> 
				</div> 
			</div> 
			</div>
            <div class="col-md-7"> 
			<div class="col-sm-10">

		<div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
			<!-- Indicators -->
			<ol class="carousel-indicators">
				<li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
				<li data-target="#carousel-example-generic" data-slide-to="1"></li>
				<li data-target="#carousel-example-generic" data-slide-to="2"></li>
			</ol>

			<!-- Wrapper for slides -->
			<div class="carousel-inner" role="listbox">
				<div class="item active">
					<img src="./img/Hotel2.jpg" alt="...">
					<div class="carousel-caption">
						<h2>Oriental Venice International Hotel</h2>
					</div>
				</div>
				<div class="item">
					<img src="./img/Hotel3.jpg" alt="...">
					<div class="carousel-caption">
						<h2>Sofitel Hotel in West Lake</h2>
					</div>
				</div>
				<div class="item">
					<img src="./img/Hotel4.jpg" alt="...">
					<div class="carousel-caption">
						<h2>Grand Hyatt Hotel</h2>
					</div>
				</div>
			</div>

			<!-- Controls -->
			<a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
				<span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
				<span class="sr-only">Previous</span>
			</a>
			<a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
				<span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
				<span class="sr-only">Next</span>
			</a>
			</div>
			</div>
		</div>
	</div> 
	
	<!---->
	</br>
		<h2><strong><center>Making your trip more enjoyable!</center></strong></h2>
	</br>


	<!-- Display figure image-->
	<div class="contrain">
		<div class="row">
		<div class="col-md-1"></div> 
		<div class="col-md-2">
		<div class="photo">
			<figure class="effect-milo">
				<img src="./img/American.jpg" alt="..." class="img-thumbnail"/>
				<figcaption>
					<h4 style="color:white">American</h4>
					<p style="color:white;margin:0;padding:0;">&nbsp;&nbsp;New York City&nbsp;&nbsp;</p>
					<p style="color:white;margin:0;padding:0;">&nbsp;Washington, D.C.&nbsp;&nbsp;</p>				
				</figcaption>			
			</figure>
		</div>
		</div>

		<div class="col-md-2">
		<div class="photo">
			<figure class="effect-milo">
				<img src="./img/England.jpg" alt="..." class="img-thumbnail"/>
				<figcaption>
					<h4 style="color:white">England</h4>
					<p style="color:white;margin:0;padding:0;">&nbsp;&nbsp;London&nbsp;&nbsp;</p>
					<p style="color:white;margin:0;padding:0;">&nbsp;&nbsp;Manchester&nbsp;&nbsp;</p>	
				</figcaption>			
			</figure>
		</div>
		</div>

		<div class="col-md-2">
		<div class="photo">
			<figure class="effect-milo">
				<img src="./img/china.jpg" alt="..." class="img-thumbnail"/>
				<figcaption>
					<h4 style="color:white">China</h4>
					<p style="color:white;margin:0;padding:0;">&nbsp;&nbsp;Beijing&nbsp;&nbsp;</p>
					<p style="color:white;margin:0;padding:0;">&nbsp;&nbsp;Shanghai&nbsp;&nbsp;</p>
				</figcaption>			
			</figure>
		</div>
		</div>

		<div class="col-md-2">
		<div class="photo">
			<figure class="effect-milo">
				<img src="./img/French.jpg" alt="..." class="img-thumbnail"/>
				<figcaption>
					<h4 style="color:white">French</h4>
					<p style="color:white;margin:0;padding:0;">&nbsp;&nbsp;Paries&nbsp;&nbsp;</p>
					<p style="color:white;margin:0;padding:0;">&nbsp;&nbsp;Marseille&nbsp;&nbsp;</p>
				</figcaption>			
			</figure>
		</div>
		</div>

		<div class="col-md-2">
		<div class="photo">
		<figure class="effect-milo">
            <img src="./img/India.jpg" alt="..." class="img-thumbnail"/>
            <figcaption>
                <h4 style="color:white">India</h4>
				<p style="color:white;margin:0;padding:0;">&nbsp;Mumbai&nbsp;&nbsp;</p>
                <p style="color:white;margin:0;padding:0;">&nbsp;Bengaluru&nbsp;&nbsp;</p>
            </figcaption>			
        </figure>
		</div>
	</div>



	<div class="clear"></div>

	<br/>
	<br/>

	</div>
	</div>

	<div></br></br></br></br></div>

	<!-- footer -->
	<div class="navbar navbar-inverse navbar-fixed-bottom">
		<div class="contrainer">
			<p class="navbar-text">Site Built By Walter</p>	
		<div>
	</div>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
	<script src="js/bootstrap3-typeahead.min.js"></script>
	<script src="js/Index.js"></script>
		
		
  </body>
</html>
