<?php
	$host = "localhost"; // Host name 
	$db_username = "root"; // Mysql username 
	$db_password = ""; // Mysql password 
	$db_name = "cz3003"; // Database name 

	//variables submitted by user
	
	$loginuser = $_POST["loginuser"];
	$loginpass = $_POST["loginpass"];
	//$loginuser = "john";
	//$loginpass = "password1";
	
	$conn = new mysqli($host,$db_username,$db_password,$db_name);
	if($conn->connect_error)
	{
		die("connection failed : " . $conn->$connect_error);
	}
	
	//echo "Hello, todya is". date("Y-m-d H:i:s");
	
	
	$sql = "Select password FROM login WHERE username ='$loginuser' " ;  
	
	$result = $conn ->query($sql);
	$row = $result->fetch_assoc();
	$var1 = $row["password"];
	if(password_verify($loginpass,$var1)==0)
	{
		echo "Error";
	}
	else
	{
		echo"Success";
	}
	
	$conn->close();
?>