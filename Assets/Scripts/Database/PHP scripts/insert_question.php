<?php
	$host = "localhost"; // Host name 
	$db_username = "root"; // Mysql username 
	$db_password = ""; // Mysql password 
	$db_name = "cz3003"; // Database name 

	//variables submitted by user
    $question_description = $_POST["question_description"];
    $answer_1 = $_POST["answer_1"];
    $answer_2 = $_POST["answer_2"];
    $answer_3 = $_POST["answer_3"];
    $answer_4 = $_POST["answer_4"];
    $correct_answer = $_POST["correct_answer"];
    $topic = $_POST["topic"];
	$difficulty = $_POST["difficulty"];

    // $question_description = "english question";
    // $answer_1 = "a";
    // $answer_2 = "b";
    // $answer_3 = "c";
    // $answer_4 = "d";
    // $correct_answer = "d";
    // $topic = "english";
	// $difficulty = "easy";
	
	$conn = new mysqli($host,$db_username,$db_password,$db_name);
	if($conn->connect_error)
	{
		die("connection failed : " . $conn->$connect_error);
	}

	$sql = "INSERT INTO question_bank (`question_description`, `answer_1`, `answer_2`, `answer_3`, `answer_4`, `correct_answer`, `topic`, `difficulty`, `assignment_id`)
            VALUES ('$question_description', '$answer_1', '$answer_2', '$answer_3', '$answer_4', '$correct_answer', '$topic', '$difficulty', 0)";  
	$result = $conn ->query($sql);
	$affected = $conn -> affected_rows;
    echo $affected;
    if($affected == 1){
        echo 'Inserted';
    } else{
        echo 'Did not insert';
    }
	$conn->close();
?>