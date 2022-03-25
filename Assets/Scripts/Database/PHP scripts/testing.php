<?php
	$host = "localhost"; // Host name 
	$db_username = "root"; // Mysql username 
	$db_password = ""; // Mysql password 
	$db_name = "cz3003"; // Database name 

	//variables submitted by user
	
	
	$conn = new mysqli($host,$db_username,$db_password,$db_name);
	if($conn->connect_error)
	{
		die("connection failed : " . $conn->$connect_error);
	}

	$sql = "Select * FROM question_bank " ;  
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