   M S B A M L   `   `   `  ����  PoIS_Rent-a-Car$    PoIS_Rent_a_Car.Forme.Korisnik   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5	   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $	��480��5   	   $	��720��6    � 
ResizeMode$ NoResize=�6"    � WindowStartupLocation$ CenterScreen=�68   .��5      � .+�5   
   �� $��	10,10,5,0q�6   $
��Wrap=�6'   $��46��6;   $��36(�6G   $��Perpetua Titling MT)�6U   $$��  ADD NEW Customer INFORMATION��6v   ���	#FF673AB7$	��Top=�6�   �� 5   
   $��1q�6   $
��Left=�6%   $	��234��6@   $��	23,94,0,0q�6M   $	��Top=�6`   $	��310��6x     	DynamicBG#���  6�   ._�5      �� $��Personal information��6   ���	#FF673AB7$��Italic$�6K   $��0,0,0,0q�6^   5      �� 5   
   
���   �$��1q�6%   $
��Left=�69   $	��165��6T   $��
366,94,0,0q�6a   $	��Top=�6u   $	��310��6�   ._�5      �� $��Contact information��6   ���	#FF673AB7$��Italic$�6J   $��0,0,0,0q�6]   5      �� 5   
   -   5         ��Name$ txtName��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$    First name��6#   $
��Left=�6R   $��23��6m   $��
77,135,0,0q�6y    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��160��6�   �� 5   
   -   5        $ 	txtSecond��5      $    Second name��6%   $
��Left=�6U   $��23��6p   $��
77,175,0,0q�6|   $
 Wrap=�6�   $	��Top=�6�   $	��160��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ 	dataBirth��5      $    Birth Date��6(   $
��Left=�6W   $��
77,222,0,0q�6r   $	��Top=�6�    J� RenderTransformOrigin$ -11.333,-6.32&�6�   	   FirstDayOfWeek$	 Monday=�6�   $	��107��6�   �� 5   
   -   5        $ txtPhone��5      $    Phone��6$   $
��Left=�6N   $��23��6i   $��429,135,0,0q�6u   $
 Wrap=�6�   $	��Top=�6�   $	��161��6�   �� 5   
   -   5        $ txtEmail��5      $ 	   e-mail��6$   $
��Left=�6O   $��23��6j   $��429,175,0,0q�6v   $
 Wrap=�6�   $	��Top=�6�   $	��161��6�   	� 5   
   -   5        
 	�Name$
 rbMale��5       d� 	IsChecked$
 TrueY�6&   $
��Male��67   $
��Left=�6F   $��
77,264,0,0q�6a   $	��Top=�6u   	� 5   
   -   5        $
 rbFemale��5      $��Female��6(   $
��Left=�69   $��177,264,0,0q�6T   $	��Top=�6i   '  !MaterialDesignThemes.Wpf.PackIcon  5   
   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ 
GenderMale=�6"   $��20��64   $��20��6@   $��132,262,0,0q�6K   $ 0.125,0.438&�6`   6�     5    
   $ GenderFemale=�6"   $��20��66   $��20��6B   $��245,262,0,0q�6M   $ 1.25,0.6&�6b   6�   �� 5!   
   -   5        $ 	txtAdress��5!      $ 	   Adress��6%   $
��Left=�6P   $��23��6k   $��429,215,0,0q�6w   $
 Wrap=�6�   $	��Top=�6�   $	��161��6�   �� 5"   
   -	   5         ��Name$ btAdd��5"      $	��ADD��64   $
��Left=�6B   $��233,385,0,0q�6]   $	��Top=�6r   $	��100��6�   �� 5#   
   -
   5        $ btDelete��5#      $��Delete��6:   
���<��$
��Left=�6`   $��366,385,0,0q�6{   $	��Top=�6�   $	��100��6�   5$      5%      