<html> 
 <head> 
  <title>�����������</title> 
 </head> 
 <body> 

 <?   
  $x=$_GET['x']; 
  $y=$_GET['y']; 
  $result=0;   
  $result=3.14*$x*$x*$y; 
  echo "����� ��������<br/>pi*R^2*H=$result<br/>";  
 ?> 

  <form action="task_5.php" method=get> 
   ������� R: <input type=text name=x><br/> 
   ������� H: <input type=text name=y><br/>
   <input type=submit value="������"> 
  </form> 
 </body> 
</html>