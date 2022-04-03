<?php
	$host = "localhost"; // Host name 
	$db_username = "root"; // Mysql username 
	$db_password = ""; // Mysql password 
	$db_name = "cz3003"; // Database name 

	//variables submitted by user
    $username = $_POST["username"];
    $score = $_POST["score"];
    $time = $_POST["time"];
    $assignment_id = $_POST["assignment_id"];


	
	$conn = new mysqli($host,$db_username,$db_password,$db_name);
	if($conn->connect_error)
	{
		die("connection failed : " . $conn->$connect_error);
	}
	
	$sql = "select * from leaderboard_custom WHERE username ='$username' AND assignment_id = '$assignment_id'";
	$result = $conn ->query($sql);
	
	if (mysqli_num_rows($result)== 0)
	{
		$sql = "INSERT INTO leaderboard_custom VALUES ('$username', '$score', '$time', '$assignment_id')";  
		$result = $conn ->query($sql);
	}
	else
	{
		$sql = "UPDATE `leaderboard_custom` SET `score`= '$score',`time`= '$time' WHERE `username` = '$username' AND `assignment_id` = '$assignment_id'";  
		$result = $conn ->query($sql);
	}
	$affected = $conn -> affected_rows;
    echo $affected;
    if($affected == 1){
        echo 'Inserted';
    } else{
        echo 'Did not insert';
    }
	$conn->close();
?>