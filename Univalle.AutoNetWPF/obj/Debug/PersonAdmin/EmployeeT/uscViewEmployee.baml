   M S B A M L   `   `   `  ����N  JUnivalle.AutoNetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Univalle.AutoNetWPF.PersonasAdmin!Univalle.AutoNetWPF.PersonasAdmin  5      3    -Univalle.AutoNetWPF.PersonasAdmin.uscEmployee   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Univalle.AutoNetWPF.PersonasAdmin     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5           MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5      .��5      � .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5         Kind$ FadeIn=�62     5      $ SlideInFromBottom=�62   .��5      � $
��auto��6   $
��auto��6!   .+�5      ��  �� CornerRadius$ 15��6   
�������._�5      � .+�5      � $	��Top=�6   $
��auto��67   $��0 20 0 0q�6G   $
��auto��6o   ��6Y   Z� .+�5      (  "MaterialDesignThemes.Wpf.ColorZone  ��67   Z� .��5   "   ]� .+�5   &   ��  �� Orientation$ 
Horizontal=�5       +  %MaterialDesignThemes.Wpf.RippleAssist   
IsCentered . .+�5"   *   �� $��
20 0 100 0q�64   $��Center=�6I    $  MaterialDesignHeadline4TextBlock#��[ 6d   $��	Empleados��6�     5$   *      Mode$ Standard=�5%   	   $��8 4 8 4q�5&   	      CornerRadius$ 2��5'   	   	 K� ZIndex$	 1��5(   	   $��16 0 0 0q�5)   	   +  %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth1=�5*   	   .��5+   .   �  � ColumnDefinitions 5,   2   �� 5-   6   $
��Auto �5.      �� 5/   6   $��* �50      �� 51   6   $
��Auto �52      .+�54   2   ��   MaterialDesignToolButton#���  55      .��56   6   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�57       J� Opacity$	 .56Q�58      59   3   �� 5:   2   $��1��5;      $��8 0 0 0q�5<      )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Buscar Empleados��5=      .
  (MaterialDesignThemes.Wpf.TextFieldAssist 
  DecorationVisibility$ Hidden=�5>      $��0q�5?      $	��200��5@      $��Center=�5A      �� 5B   2   #���  5C      $��2��5D      .��5E   6     $ 
Microphone=�5F      $	 .56Q�5G      $��8 0 0 0q�5H      5I   3   5J   /   5K   +   �� 5L   *    & "MaterialDesignToolForegroundButton#���  5M   	   $��8 0 0 0q�5N   	   $	 0��5O   	   .��5P   .     $
 Send=�5Q      5R   +   5S   '   5T   #   5U      5V      � 5W      $��	0  75 0 0q�6    $��60��63   $	��top=�6?   ���#F7F7F7.+�5X      �� $ 
Horizontal=�6)   .+�5Y   "   �� -   5        $��btnAñadirEmpleado��5Y   )   
��� � �$	��100��6U   $
��Left=�6a   $��20,0,10,0.4q�6}   $��0q�6�   .��5Z   &   �� $��Center=�61   .+�5[   *   �� $
��auto��65   $ 
Horizontal=�6C   .+�5]   .   �� $��Center=�68   $��
+ Empleado��6S   $��5q�6f   $
��auto��6q   5^   +   5_   '   5b   #   5c      5e      � 5f      -   5         �Name$ gridMainParts��5f      $��20 150 20 20q�66   .+�5j      �� $��Visible=�6+   .��5k   "   � -   5        $ gridEmployees��5k   '   $	��Top=�6?   5m   #   5n      5o      5s      5|      )  #MaterialDesignThemes.Wpf.DialogHost  5}      -   5        $��DialogoHost1��5}   ,     MaterialDesignDivider#���  6@      DialogContent 5~      � 5      .+�5�      �� $ 15��6%   $	��300��67   $	��150��6C   $��Center=�6P   
�������._�5�   "   �  5�   &   �� 5�   *   �� 5�   *    � RowDefinitions 5�   &   �� 5�   *   �� 5�   *   .+�5�   &   �� $��2��60   $��Center=�6D   $��Center=�6_   $"��¿Desea Eliminar el cliente?��6|   �� 5�   &   -   5         ��Name$  btnCancelarEliminarCliente��5�   -   $��1��6Q   $��Cancelar��6^   $��10q�6q   ���	#FF17950A���	#FF1A6C086�   �� 5�   &   -   5        $ btnEliminarCliente��5�   -   $��1��6I   $��Eliminar��6V   $��10q�6i   $��1��6u   ���	#FFDA1F1F���	#FFAC0B0B6�   5�   #   5�      5�      5�      5�      5�      5�      5�      