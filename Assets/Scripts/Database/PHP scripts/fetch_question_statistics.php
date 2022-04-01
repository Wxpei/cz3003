<?php
	$host = "localhost"; // Host name 
	$db_username = "root"; // Mysql username 
	$db_password = ""; // Mysql password 
	$db_name = "cz3003"; // Database name 

	//variables submitted by user

	$question_id = $_POST["question_id"];
	//$question_id = 1;
	
	$conn = new mysqli($host,$db_username,$db_password,$db_name);
	if($conn->connect_error)
	{
		die("connection failed : " . $conn->$connect_error);
	}

	$sql = "SELECT correct_attempts, total_attempts, ROUND(correct_attempts * 100.0 / total_attempts, 1) AS Percent 
			FROM question_bank
            WHERE question_id = '$question_id'";  
	$result = $conn ->query($sql);

	if($result->num_rows > 0)
	{
		$rows = array();
        while($row = $result->fetch_assoc())
        {
            $rows[] = $row;
        }
        echo json_encode($rows);
	}
    else{
        echo "failed";
    }
	$conn->close();
?>