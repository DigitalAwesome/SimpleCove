   M S B A M L   `   `   `  ����E  ASimpleCove, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:SimpleCove.PropertiesSimpleCove.Properties  5   	   9!clr-namespace:SimpleCove.ControlsSimpleCove.Controls  5   	       SimpleCove.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :
properties#clr-namespace:SimpleCove.Properties     5   	   6Controls!clr-namespace:SimpleCove.Controls     5   	   \ XHardcodet.Wpf.TaskbarNotification, Version=1.0.5.0, Culture=neutral, PublicKeyToken=null)tb http://www.hardcodet.net/taskbar  5   	   X TXceed.Wpf.Toolkit, Version=2.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$  
SimpleCove��5   	   $	��350��6   $	��419��6)    � Icon$ Icons/NetDrives.ico��6X    � 	Resources 5	      $  SimpleCove.Properties.Settings   Settings��%   &	          5
   
   6   5      .��5      � $��0,0,2,0q�6    � ColumnDefinitions 5   
   �� 5      $
��613* �6   �� 5      $��0* �6   �� 5      $��4* �6   .+�5   
   �� -   5        $��Apply��5      $
��Left=�6!   $��324,286,0,0q�6<   $	��Top=�6Q   $��75��6i   $��22��6�   �� 5   
   -   5        $��Cancel��5      $
��Left=�6"   $��244,286,0,0q�6=   $	��Top=�6R   $��75��6j   $��22��6�   �� 5   
   -   5         ��Name$ btnStart��5      $��Start��6#   $
��Left=�63   $��
10,226,0,0q�6N   $	��Top=�6b   $��75��6z   6�   �� 5   
   -   5        $ btnStop��5      $
��Stop��6"   $
��Left=�61   $��
10,253,0,0q�6L   $	��Top=�6`   $��75��6x   6�   �� 5   
   -   5         ��Name$ 	lblStatus��5      $��STATUS��6#   $
��Left=�64   $��
85,224,0,0q�6O   $	��Top=�6c   $	��136��6{   $��Bottom=�6�   $��Center=�6�   �� 5   
   -   5         ��Name$ txtFilePath��5      $
��Left=�6k   $��23��6�   $��	91,58,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��219��6�   ��6'   �� *Default.FilePath+ �� Source# [  6�   �� 5   
   $��Target:��6   $
��Left=�6"   $��	39,57,0,0q�6=   $	��Top=�6P   $��26��6h   $��47��6t   �� 5   
   -   5        $��	Browse...��5      $
��Left=�6%   $��
315,58,0,0q�6@   $	��Top=�6T   $��75��6l   $��22��6w   6�   �� 5   
   $��Start Time:��6   $
��Left=�6'   $��
19,119,0,0q�6B   $	��Top=�6V   �� 5   
   -	   5        $ txtDestinationPath��5      $
��Left=�6y   $��23��6�   $��	91,91,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��219��6�   ��6.   �� *Default.DestinationPath+# [  6�   �� 5   
   $��Destination:��6   $
��Left=�6'   $��	13,88,0,0q�6B   $	��Top=�6U   $��26��6m   $��73��6y   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   -
   5        	  Name$	 dtpStartTime��5      &   Xceed.Wpf.Toolkit.DateTimeUpDown
   Format$
 Custom=�5    
      FormatString$ hh:mm tt MM/dd/yyyy ��5!   
   $��
91,121,0,0q�5"   
   $
��Left=�6   $	��Top=�69   $	��173��6Q   $��23��6]   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text 5   5   �� *Default.StartTime+# [  5"   ]   	� 5#   
   -   5         	�Name$ rbDestType1��5#   2    	� 	GroupName$ rbDestTypeGroup��6   $��
FTP Server��6�   $
��Left=�6�   $��
91,166,0,0q�6�   $	��Top=�6�    d� 	IsChecked 6G   �� *Default.DestType1+# [  6�   	� 5$   
   -   5        $ rbDestType2��5$   2   $ rbDestTypeGroup��6   $��Local Drive��6�   $
��Left=�6�   $��
91,187,0,0q�6�   $	��Top=�6�    6G   �� *Default.DestType2+# [  6�   �� 5%   
   -   5        $ btnBrowseFTP��5%   %   $��	Browse...��6   $
��Left=�6;   $��
315,91,0,0q�6V   $	��Top=�6j   $��75��6�   $��22��6�   6�   �� 5&   
   -   5        $ btnFTPSettings��5&   +   $��FTP Settings...��6   $
��Left=�6C   $��182,163,0,0q�6^   $	��Top=�6s   $��94��6�   $��22��6�   6�   �� 5'   
   -   5        $��OK��5'      $
��Left=�6   $��164,286,0,0q�69   $	��Top=�6N   $��75��6f   $��22��6�   �� 5(   
   -   5        $��lblDebug��5(      $��[ DEBUG MODE ]��6    $
��Left=�69   $��
156,10,0,0q�6T   $	��Top=�6h   $	��108��6�   
���   �$
��Bold"�6�   $��2q�6�   �� 5)   
   -   5        $��
ddInterval��5)      $
��Left=�6%   $��270,121,0,0q�6@   $	��Top=�6U   $	��120��6m    �� SelectedIndex 6y   �� *Default.Interval+# [  .@�5*      �� $��Hourly��6   6.   �� 5+      $��Daily��6   6-   �� 5,      $��Weekly��6   6.   �� 5-      $��Monthly��6   6/   �� 5.      $��Yearly��6   6.   5/      51      52      