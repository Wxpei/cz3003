<?php
	$host = "localhost"; // Host name 
	$db_username = "root"; // Mysql username 
	$db_password = ""; // Mysql password 
	$db_name = "cz3003"; // Database name 

	//variables submitted by user
	
	$username = $_POST["username"];
	$password = $_POST["password"];
	$name = $_POST["name"];
	$email = $_POST["email"];
	$password = password_hash($password, PASSWORD_BCRYPT);
	$conn = new mysqli($host,$db_username,$db_password,$db_name);
	if($conn->connect_error)
	{
		die("connection failed : " . $conn->$connect_error);
	}
	
 
	//$sql = " INSERT INTO `login` (`username`, `passowrd`, `isTeacher`, `Name`, `Email`) VALUES ('$username', '$password', '0', '$name', '$email')";
	$sql = "select * from login WHERE username ='$username'";
	$result = $conn ->query($sql);

	
	if (mysqli_num_rows($result)==0)
	{
		$sql = " INSERT INTO `login` (`username`, `password`, `isTeacher`, `Name`, `Email`) VALUES ('$username', '$password', '0', '$name', '$email')";
		$ver = mysqli_query($conn, $sql);
		if($ver)
		{
			echo"added";
		}
	}
	else
	{
		echo "exist";
	}
	$conn->close();
?>