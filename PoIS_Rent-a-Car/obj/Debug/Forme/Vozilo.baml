   M S B A M L   `   `   `  ����  PoIS_Rent-a-Car"    PoIS_Rent_a_Car.Forme.Vozilo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5	   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $	��480��5      $	��720��6'    � 
ResizeMode$ NoResize=�63    � WindowStartupLocation$ CenterScreen=�6I   .��5      � .+�5   
   �� $��113,19,141,0q�6   $
��Wrap=�6*   $��64��6>   $��45(�6J   $��Perpetua Titling MT)�6X   $��  ADD NEW VEHICLE��6y   ���	#FF673AB7$	��Top=�6�   �� 5   
   ���	#FF673AB7$��1q�6)   $
��Left=�6=   $	��254��6X   $��	10,88,0,0q�6e   $	��Top=�6x   $	��671��6�   ._�5      �� -   5         ��Name$ cbMake��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$    Make��6'   $��65,56,442,168q�6P   .@�5      �� $��
Alfa Romeo��6   �� 5      $
��Audi��6   �� 5      $	��BMW��6   �� 5      $��	Chevrolet��6   �� 5      $
��FIAT��6   �� 5      $
��Ford��6   �� 5      $��Honda��6   �� 5      $	��Kia��6   �� 5      $��Mercedes��6   �� 5      $��Nissan��6   �� 5      $��Tesla��6   �� 5      $��Toyota��6   �� 5      $��VW��6   5       5!      �� 5"   
   -   5         ��Name$ txtModel��5"      $    Model��6$   $
��Left=�6N   $��23��6i   $��
78,194,0,0q�6u    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 5#   
   -   5         ��Name$ chAir��5#      $��Air conditioning��6"   $
��Left=�6=   $��
78,250,0,0q�6X   $	��Top=�6l   	 J� RenderTransformOrigin$	 0.509,0.056&�6�   �� 5$   
   -   5        $ cbTransmission��5$      $    Transmission��6+   $
��Left=�6\   $��376,148,0,0q�6w   $	��Top=�6�   $	��179��6�   .@�5%      �� $��Manual��6   �� 5&      $��	Automatic��6   �� 5'      $��Semi-automatic��6   �� 5(      $	��CVT��6   5)      �� 5*   
   -   5        $ cbType��5*      $    Car Type��6#   $
��Left=�6P   $��
78,287,0,0q�6k   $	��Top=�6   $	��162��6�   .@�5+      �� $��Small��6   �� 5,      $��Mid-size��6   �� 5-      $��	Full-size��6   �� 5.      $	��SUV��6   �� 5/      $��Sports��6   �� 50      $��Luxury��6   �� 51      $
��Vans��6   52      	� 53   
   -   5        
 	�Name$
 rbSeats2��53      $��2 seat��6(   $
��Left=�69   $��376,199,0,0q�6T   $	��Top=�6i   $	 0.768,0.556&�6�   	� 54   
   -   5        $
 rbSeats4��54      $��4 seat��6(   $
��Left=�69   $��462,199,0,0q�6T   $	��Top=�6i   $	 0.875,0.444&�6�   	� 55   
   -   5        $
 rbSeats5��55      $��5 seat��6(   $
��Left=�69   $��546,199,0,0q�6T   $	��Top=�6i   �� 56   
   -	   5        $ txtFuel��56      $    km/l��6#   $
��Left=�6L   $��23��6g   $��376,250,0,0q�6s   $
 Wrap=�6�   $	��Top=�6�   $	��120��6�   �� 57   
   -
   5        $ txtPrice��57      $    Price per day €��6$   $
��Left=�6X   $��23��6s   $��376,292,0,0q�6   $
 Wrap=�6�   $	��Top=�6�   $	��129��6�   �� 58   
   -   5         ��Name$ btAdd��58      $	��ADD��64   $
��Left=�6B   $��191,373,0,0q�6]   $	��Top=�6r   $	��100��6�   $	 
0.37,0.438&�6�   �� 59   
   -   5        $ btCancel��59      $��Cancel��6:   
���<��$
��Left=�6`   $��376,373,0,0q�6{   $	��Top=�6�   $	��100��6�   5;      5<      