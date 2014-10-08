<?php
session_start();
$pageTitle = 'Upload';
include 'include/header.php';

if($_SESSION['isLoged']!=true){
	echo 'You must login!';
}
else
{
		//echo '<pre>'.print_r($_FILES,true).'</pre>';
		include 'include/choise.php';
		if(count($_FILES)>0){
			$filename = $_FILES['picture']['tmp_name'];
	
			$destination = 'uploaded'.DIRECTORY_SEPARATOR.$_FILES['picture']['name'];
	
			if(move_uploaded_file($filename, $destination)){
				echo 'File was sucsessfully write';	
			}
			else{
				echo 'Not uploaded file';	
			}
		}
		echo "</br>";
		?>
		<form method="post" enctype="multipart/form-data"> 
		   
		   <p class="text_upload">
				Upload file to web server
		   </p>
			<div id="pic_upload">
				<input type="file" name="picture" />
			</div>
			<div id="pic_upload_but">
				<input type="submit" value="Upload File" />
			</div>
		</form>
		
		<?php
}
include 'include/footer.php';
?>

