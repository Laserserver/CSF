<html> 
 <head> 
  <title>Калькулятор</title> 
 </head> 
 <body> 

 <?   
  $x=$_GET['x']; 
  $y=$_GET['y']; 
  $result=0;   
  $result=3.14*$x*$x*$y; 
  echo "Объём цилиндра<br/>pi*R^2*H=$result<br/>";  
 ?> 

  <form action="task_5.php" method=get> 
   Введите R: <input type=text name=x><br/> 
   Введите H: <input type=text name=y><br/>
   <input type=submit value="Считай"> 
  </form> 
 </body> 
</html>