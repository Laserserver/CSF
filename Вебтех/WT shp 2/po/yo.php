<?
      $name = $_POST['name'];
      $pol = $_POST['pol'];
	    $rasa = $_POST['rasa'];
		$rasa = $_POST['klass'];
		$file ='rent.txt';
      if(empty($_POST['name']))
      {
      echo 'Введите имя персонажа';
      }
	   elseif(!preg_match('/^[а-яА-ЯёЁa-zA-Z0-9\d]+$/iu',$name)){
 
   echo 'Запрещенные символы';
 
}
	  else{
		  if(file_exists($file))
		  {
		  $fp = fopen("rent.txt", "a");
  fputs($fp,$_POST['name'].PHP_EOL);
  fputs($fp,$_POST['pol'].PHP_EOL);
  fputs($fp,$_POST['rasa'].PHP_EOL);
  fputs($fp,$_POST['klass'].PHP_EOL);
fclose($fp);
	  
	  
	  echo'УСПЕХ';
		  }
		  else{echo'ошибка открытия файла!';}
	  } 

?>
