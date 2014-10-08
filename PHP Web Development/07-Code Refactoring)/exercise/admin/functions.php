<?php
session_start ();
mb_internal_encoding ( 'UTF-8' );
$con = mysqli_connect ( 'localhost', 'user', 'querty', 'books' );
if (! $con) {
	// error
	echo 'No connecion with database';
	exit ();
}
mysqli_set_charset ( $con, 'UTF8' );
function getAuthorsAndBooks($book_id, $con) {
	$book_id = mysqli_escape_string ( $con, $book_id );
	$sql = 'select b.book_title, a.author_name 
			from books_authors as ba
			right join books as b on ba.book_id = b.book_id
			right join authors as a on ba.author_id = a.author_id
			where b.book_id =' . $book_id . '';
	$result = mysqli_query ( $con, $sql );
	$data = array ();
	$title;
	while ( $row = $result->fetch_assoc () ) {
		// echo '<pre>user_id: '.print_r($row,true).'</pre>';
		// $data[$row['book_title']]['author_name'] = $row['author_name'];
		$title ['title'] = $row ['book_title'];
		$data [] = $row ['author_name'];
	}
	$autors_temp = array ();
	foreach ( $data as $key => $go ) {
		$autors_temp [] = $go;
	}
	$autors_temp = implode ( ', ', $autors_temp );
	echo '<div id="book_name">Име на книгата: <span class="bo_li">' . $title ['title'] . '</span></div><br/>';
	echo '<div id="autors_name">Автори: <span class="bo_li">' . $autors_temp . '</span></div>';
}
function addComments($book_id, $text, $con) {
	if ((isset ( $_SESSION ['username'] ))) {
		// get user_id
		$text = mysqli_escape_string ( $con, $text );
		$book_id = mysqli_escape_string ( $con, $book_id );
		$sql1 = 'select user_id from users where username= "' . $_SESSION ['username'] . '"';
		$result = mysqli_query ( $con, $sql1 );
		$user_id = mysqli_fetch_row ( $result );
		$user_id = ( int ) $user_id [0];
		// insert comment
		$sql2 = 'insert into comments (book_id,date, text, user_id) values(' . $book_id . ',now(),"' . $text . '",' . $user_id . ')';
		mysqli_query ( $con, $sql2 );
	}
}
function showComments($book_id, $con) {
	$sql = 'select * from comments where book_id = "' . $book_id . '" order by date desc';
	$result = mysqli_query ( $con, $sql );
	$count = 1;
	while ( $row = $result->fetch_assoc () ) {
		$username = getUsername ( $row ['user_id'], $con );
		// echo '<pre>'.print_r($num_row,true).'</pre>';
		echo '<tr>
				 <td>' . $count . '</td>
				 <td>' . $row ['text'] . '</td>
				 <td>' . print_r ( $username, true ) . '</td>
				 <td>' . $row ['date'] . '</td>
			  </tr>';
		$count ++;
	}
	echo '</table>';
}
function getUsername($user_id, $con) {
	$sql2 = 'select username from users where user_id = ' . $user_id . '';
	$result2 = mysqli_query ( $con, $sql2 );
	$username;
	// echo '<pre>'.print_r($num_row,true).'</pre>';
	while ( $row2 = $result2->fetch_assoc () ) {
		$username = $row2 ['username'];
	}
	return $username;
}
function addAutor($autor, $con) {
	$autor = mysqli_escape_string ( $con, $autor );
	$sql = 'insert into authors (author_name) values("' . $autor . '") ';
	mysqli_query ( $con, $sql );
	return 1;
}
function checkExistuser($username, $con) {
	$username = mysqli_escape_string ( $con, $username );
	$sql = 'select user_id from users where username = "' . $username . '"';
	$result = mysqli_query ( $con, $sql );
	$row = $result->fetch_assoc ();
	if (! ($row)) {
		return 1;
	}
}
function addUser($username, $password, $con) {
	$username = mysqli_escape_string ( $con, $username );
	$password = mysqli_escape_string ( $con, $password );
	$sql = 'insert into users (username, password) values ("' . $username . '","' . $password . '")';
	mysqli_query ( $con, $sql );
	$_SESSION ['username'] = $username;
	return true;
}
function checkLogin($username, $password, $con) {
	$sql = 'select user_id from users where username = "' . $username . '" and password = "' . $password . '"';
	$result = mysqli_query ( $con, $sql );
	while ( $row = $result->fetch_assoc () ) {
		// echo '<pre>'.print_r($row,true).'</pre>';
		if ($row ['user_id'] != null) {
			$_SESSION ['username'] = $username;
			return true;
		}
	}
	return false;
}
function addBook($book, $autors, $con) {
	$sql = 'insert into books (book_title) values("' . $book . '") ';
	mysqli_query ( $con, $sql );
	$book_id = mysqli_query ( $con, 'select book_id from books as b where b.book_title = "' . $book . '"' )->fetch_assoc ();
	$book_id = $book_id ['book_id'];
	echo $book_id;
	// add autors to book
	if ($autors != null) {
		echo '<pre>' . print_r ( $autors [0], true ) . '</pre>';
		foreach ( $autors [0] as $autor_id ) {
			echo $autor_id;
			$sql2 = 'insert into books_authors 
					(book_id, author_id) 
					values (' . $book_id . ',' . $autor_id . ')';
			mysqli_query ( $con, $sql2 );
		}
	}
	
	return 1;
}
function showAutors($con) {
	$sql = 'select * from authors';
	$result = mysqli_query ( $con, $sql );
	
	while ( $row = $result->fetch_assoc () ) {
		// $autor = $row['author_name'];
		$autor = '<a href="booksFromAuthor.php?author_id=' . $row ['author_id'] . '">' . $row ['author_name'] . '</a>';
		
		echo '<tr><td>' . $autor . 		// must be link to ...
		'</td></tr>';
	}
	echo '</table>';
}
function showBookAndAutors($con) {
	$sql = 'select * from books_authors as ba
			join books as b
			on ba.book_id = b.book_id
			join authors as a
			on ba.author_id = a.author_id';
	$result = mysqli_query ( $con, $sql );
	$data = array ();
	while ( $row = $result->fetch_assoc () ) {
		
		$data [$row ['book_id']] ['books'] = $row ['book_title'];
		$data [$row ['book_id']] ['authors'] [$row ['author_id']] = $row ['author_name'];
		// $data[$row['book_id']]['authors_id'][] = $row['author_name'];
	}
	$count = 1;
	foreach ( $data as $key => $books_m ) {
		// echo '<pre>'.print_r($key,true).'</pre>';
		echo '<tr><td>' . $count . '</td><td><a href="book.php?book_id=' . $key . '">' . $books_m ['books'] . '</a></td>';
		$books_temp = array ();
		foreach ( $books_m ['authors'] as $key => $autors_m ) {
			
			$books_temp [] = '<a href="booksFromAuthor.php?author_id=' . $key . '">' . $autors_m . '</a>';
			// <a href="index.php">Книги</a>
		}
		$books_temp = implode ( ', ', $books_temp );
		echo '<td>' . $books_temp . '</td></tr>';
		$count ++;
	}
	echo '</table>';
}
function getAuthorName($author_id, $con) {
	$sql = 'select author_name from authors as a
			where a.author_id =' . $author_id;
	$result = mysqli_query ( $con, $sql )->fetch_assoc ();
	return $result ['author_name'];
}
function showBookFromAutors($author_id, $con) {
	$sql = 'select * from books_authors as ba
			join books as b
			on ba.book_id = b.book_id
			join authors as a
			on ba.author_id = a.author_id
			where ba.author_id = ' . $author_id;
	$result = mysqli_query ( $con, $sql );
	$autor_name = getAuthorName ( $author_id, $con );
	echo '<table width="100%" border="1" cellspacing="0" cellpadding="0">
			<tr><th>Книга</th><th>Съавтори на ' . $autor_name . '</th></tr>';
	while ( $row = $result->fetch_assoc () ) {
		$sql2 = 'select a.author_name,a.author_id from books_authors as ba
				join books as b
				on ba.book_id = b.book_id and b.book_id = ' . $row ['book_id'] . '
				join authors as a
				on ba.author_id = a.author_id';
		$result2 = mysqli_query ( $con, $sql2 );
		$books_temp = array ();
		while ( $row2 = $result2->fetch_assoc () ) {
			if ($autor_name != $row2 ['author_name']) {
				$books_temp [] = '<a href="booksFromAuthor.php?author_id=' . $row2 ['author_id'] . '">' . $row2 ['author_name'] . '</a>';
			}
		}
		$books_temp = implode ( ',', $books_temp );
		echo '<tr><td>' . $row ['book_title'] . '</td><td>' . $books_temp . '</td></tr>';
	}
	echo '</table>';
}
function generateOption($con) {
	$sql = 'select * from authors';
	$result = mysqli_query ( $con, $sql );
	while ( $row = $result->fetch_assoc () ) {
		echo '<option value="' . $row ['author_id'] . '">' . $row ['author_name'] . '</option>';
	}
}

?>