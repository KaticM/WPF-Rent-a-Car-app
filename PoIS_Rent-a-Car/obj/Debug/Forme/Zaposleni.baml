   M S B A M L   `   `   `  ����  PoIS_Rent-a-Car%    PoIS_Rent_a_Car.Forme.Zaposleni   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5	   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $	��480��5      $	��720��6'    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I   .��5      � .+�5   
   �� $��	10,10,5,0q�6   $
��Wrap=�6'   $��46��6;   $��36(�6G   $��Perpetua Titling MT)�6U   $$��  ADD NEW EMPLOYEE INFORMATION��6v   ���	#FF673AB7$	��Top=�6�   �� 5   
   $��1q�6   $
��Left=�6%   $	��250��6@   $��	23,94,0,0q�6M   $	��Top=�6`   $	��310��6x     	DynamicBG#���  6�   ._�5      �� $��Personal information��6   ���	#FF673AB7$��Italic$�6K   $��0,0,0,0q�6^   5      �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��160��6T   $��
366,94,0,0q�6a   $	��Top=�6u   $	��310��6�   ._�5      �� $��Contact information��6   ���	#FF673AB7$��Italic$�6J   $��0,0,0,0q�6]   5      �� 5   
   -   5         ��Name$ txtName��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$    First name��6#   $
��Left=�6R   $��23��6m   $��
77,135,0,0q�6y    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��160��6�   �� 5   
   -   5        $ 	txtSecond��5      $    Second name��6%   $
��Left=�6U   $��23��6p   $��
77,185,0,0q�6|   $
 Wrap=�6�   $	��Top=�6�   $	��160��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	dataBirth��5      $    Birth Date��6(   $
��Left=�6W   $��
77,242,0,0q�6r   $	��Top=�6�    J� RenderTransformOrigin$ -11.333,-6.32&�6�   	   FirstDayOfWeek$	 Monday=�6�   $	��107��6�   �� 5   
   -   5        $ txtPhone��5      $    Phone��6$   $
��Left=�6N   $��23��6i   $��429,135,0,0q�6u   $
 Wrap=�6�   $	��Top=�6�   $	��161��6�   �� 5   
   -   5        $ txtEmail��5      $ 	   e-mail��6$   $
��Left=�6O   $��23��6j   $��429,175,0,0q�6v   $
 Wrap=�6�   $	��Top=�6�   $	��161��6�   	� 5   
   -   5        
 	�Name$
 rbMale��5      $
��Male��6&   $
��Left=�65   $��
77,294,0,0q�6P   $	��Top=�6d   	� 5   
   -   5        $
 rbFemale��5      $��Female��6(   $
��Left=�69   $��177,294,0,0q�6T   $	��Top=�6i   '  !MaterialDesignThemes.Wpf.PackIcon  5   
   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ 
GenderMale=�6"   $��20��64   $��20��6@   $��132,294,0,0q�6K   $ 0.125,0.438&�6`   6�     5   
   $ GenderFemale=�6"   $��20��66   $��20��6B   $��245,294,0,0q�6M   $ 1.25,0.6&�6b   6�   �� 5    
   -   5         ��Name$ cbCity��5       $    City��6#   $
��Left=�6L   $��429,219,0,0q�6g   $	��Top=�6|   $	��124��6�   .@�5!      �� $��Beograd��6   
����+��6-   �� 5"      $��Novi Sad��6   ���	#FF673AB76.   �� 5#      $	��Nis��6   
����+��6)   5$      �� 5%   
   
���   �$��1q�6%   $
��Left=�69   $��80��6T   $��366,264,0,0q�6`   $	��Top=�6u   $	��310��6�   ._�5&      �� $��Employment Information��6   ���	#FF673AB7$��Italic$�6M   $��0,0,0,0q�6`   5'      �� 5(   
   -	   5        $ cbTitle��5(      $    Job Title��6$   $
��Left=�6R   $��383,294,0,0q�6m   $	��Top=�6�   $	��125��6�   .@�5)      �� $��Rental Sales Agent��6   �� 5*      $��Vehicle Service Agent��6   �� 5+      $��Return Agent��6   �� 5,      $��Car Detailer��6   �� 5-      $��Location Manager��6   5.      �� 5/   
   -
   5        $ cbType��5/      $    Employment Type��6#   $
��Left=�6W   $��530,294,0,0q�6r   $	��Top=�6�   $	��131��6�   .@�50      �� $��	Full-Time��6   �� 51      $��	Part-Time��6   �� 52      $��
Fixed Term��6   �� 53      $��Trainees��6   �� 54      $��	Probation��6   55      �� 56   
   -   5         ��Name$ btAdd��56      $	��ADD��64   $
��Left=�6B   $��233,385,0,0q�6]   $	��Top=�6r   $	��100��6�   �� 57   
   -   5        $ btDelete��57      $��Delete��6:   
���<��$
��Left=�6`   $��366,385,0,0q�6{   $	��Top=�6�   $	��100��6�   58      59      