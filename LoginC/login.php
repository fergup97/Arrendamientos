<?php

$dbhost = "localhost";
$dbuser = "root";
$dbpass = "";
$dbname = "test";

$conn = mysqli_connect($dbhost, $dbuser, $dbpass, $dbname);
if (!$conn) 
{
	die("No hay conexión: ".mysqli_connect_error());
}

$nombre = $_POST["email"];
$pass = $_POST["pass"];

$query = mysqli_query($conn,"SELECT * FROM login WHERE email = '".$nombre."' and password = '".$pass."'");
$nr = mysqli_num_rows($query);

if($nr == 1)
{
	echo "<script> alert('Bienvenido $nombre');window.location= 'index.html' </script>";
}
else if ($nr == 0) 
{

	echo "<script> alert('Usuario no existe');window.location= 'index.html' </script>";
}
	


?>