<?php

$con = mysqli_connect('localhost','user','querty','books');
if(!$con){
	//error
	echo 'No connecion with database';
	exit;
}
mysqli_set_charset($con,'UTF8');

function addAutor($autor, $con){
	$sql = 'insert into authors (author_name) values("'.$autor.'") ';
	mysqli_query($con,$sql);
	return 1;
}

function addBook($book, $autors, $con){
	$sql = 'insert into books (book_title) values("'.$book.'") ';
	mysqli_query($con,$sql);
	$book_id = mysqli_query($con,'select book_id from books as b where b.book_title = "'.$book.'"')->fetch_assoc();
	$book_id = $book_id['book_id'];
	echo $book_id;
	//add autors to book
	if($autors!=null){
		echo '<pre>'.print_r($autors[0],true).'</pre>';
		foreach($autors[0] as $autor_id){
			echo $autor_id;
			$sql2 = 'insert into books_authors 
					(book_id, author_id) 
					values ('.$book_id.','.$autor_id.')';
			mysqli_query($con,$sql2);
		}
	}
	
	return 1;
}

function showAutors($con){
	$sql = 'select * from authors';
	$result = mysqli_query($con,$sql);
	
	while($row = $result->fetch_assoc())
	{
		//$autor = $row['author_name'];
		$autor = '<a href="booksFromAuthor.php?author_id='.$row['author_id'].'">'.$row['author_name'].'</a>';
		
		echo '<tr><td>'
			.$autor // must be link to ...
			.'</td></tr>';
	}
	echo '</table>';
}

function showBookAndAutors($con){
	$sql = 'select * from books_authors as ba
			join books as b
			on ba.book_id = b.book_id
			join authors as a
			on ba.author_id = a.author_id';
	$result = mysqli_query($con,$sql);
	$data = array();
	while($row = $result->fetch_assoc()){
		
		$data[$row['book_id']]['books'] = $row['book_title'];
		$data[$row['book_id']]['authors'][$row['author_id']] = $row['author_name'];
		//$data[$row['book_id']]['authors_id'][] = $row['author_name'];
	}
	$count =1;
	foreach($data as $books_m){
		echo '<tr><td>'.$count.'</td><td>'.$books_m['books'].'</td>';
		$books_temp = array();
		foreach($books_m['authors'] as $key => $autors_m){
			
			$books_temp[] = '<a href="booksFromAuthor.php?author_id='.$key.'">'.$autors_m.'</a>';
			//<a href="index.php">Книги</a>
		}
		$books_temp = implode(', ',$books_temp);
		echo '<td>'.$books_temp.'</td></tr>';
		$count++;
	}
	echo '</table>';
}
function getAuthorName($author_id,$con){
	$sql = 'select author_name from authors as a
			where a.author_id ='.$author_id;
	$result = mysqli_query($con,$sql)->fetch_assoc();
	return $result['author_name'];
}

function showBookFromAutors($author_id, $con){
	$sql = 'select * from books_authors as ba
			join books as b
			on ba.book_id = b.book_id
			join authors as a
			on ba.author_id = a.author_id
			where ba.author_id = '.$author_id;
	$result = mysqli_query($con,$sql);
	$autor_name = getAuthorName($author_id,$con);
	echo '<table width="100%" border="1" cellspacing="0" cellpadding="0">
			<tr><th>Книга</th><th>Съавтори на '.$autor_name.'</th></tr>';
	while($row = $result->fetch_assoc()){
		$sql2 = 'select a.author_name,a.author_id from books_authors as ba
				join books as b
				on ba.book_id = b.book_id and b.book_id = '.$row['book_id'].'
				join authors as a
				on ba.author_id = a.author_id';
		$result2 = mysqli_query($con,$sql2);	
		$books_temp = array();
		while($row2 = $result2->fetch_assoc()){	
			if($autor_name!=$row2['author_name']){
				$books_temp[] = '<a href="booksFromAuthor.php?author_id='.$row2['author_id'].'">'.$row2['author_name'].'</a>';
			}
			
		}
		$books_temp = implode(',',$books_temp);
		echo '<tr><td>'.$row['book_title'].'</td><td>'.$books_temp.'</td></tr>';
	}
	echo '</table>';
}

function generateOption($con){
	$sql = 'select * from authors';
	$result = mysqli_query($con,$sql);
	while($row = $result->fetch_assoc()){	
		echo '<option value="'.$row['author_id'].'">'.$row['author_name'].'</option>';
	}
}

?>