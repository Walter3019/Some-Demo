<?php
	// set header 
	header('content-Type:application/json');
	
	// if query is set by get method.
	if(!isset($_GET['query'])){
		echo 0;
		exit();
	}

	// connect to mysql database.
	$pdo = new PDO('mysql:host=127.0.0.1;dbname=UMS', 'root', 'root');
	
	// make a prepare.
	$city = $pdo->prepare("
		SELECT distinct City 
		FROM HotelInfo 
		WHERE City Like :query
	");

	// set :query value, and get result from database.
	$city->execute(array(
		':query' => "{$_GET['query']}%")
	);

	// return JSON.
	echo json_encode($city->fetchAll());
?>