   M S B A M L   `   `   `  ����N  JUnivalle.AutoNetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Univalle.AutoNetWPF.PersonAdmin.ClientT'Univalle.AutoNetWPF.PersonAdmin.ClientT  5   	   <    6Univalle.AutoNetWPF.PersonAdmin.ClientT.ViewClientInfo   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Glocal5clr-namespace:Univalle.AutoNetWPF.PersonAdmin.ClientT     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	   $	��600��5   	   $
��1000��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency . ��5   	   Z� .��5      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 20Q�6   $	��520��63   $	��900��6@   .��5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5      	   Kind$	 FadeIn=�62     5      $	 SlideInFromBottom=�62   .��5      � $	��520��6   $	��900��6"   ��6/   Z� .+�5      �� 
 �� CornerRadius$
 15��6   $��10q�6+   
�������._�5       � $��20q�6    � ColumnDefinitions 5!      �� 5"      $��* �6/   �� 5#      $
��1.3* �6/    � RowDefinitions 5%      �� 5&      $��30 �6,   �� 5'      $��* �6,   .+�5)      � $��2��6"   .+�5*      ��  �� Orientation$ 
Horizontal=�6*   $��Right=�6D   $��
0,0,10,0.4q�6`   $	��820��6t   .+�5+   "   �� -   5         ��Name$ 	btnEditar��5+   )   
���   �$��60��6Q   $��30��6\   
���   �$��Right=�6�   $	��Top=�6�   ��6{   Z� .��5,   &   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Edit=�6>   5-   #   �� 5.   "   -   5        $ btnEliminar��5.   )   $��	10 0 10 0q�6>   $��Right=�6Q   
���   �$��60��6�   $
��auto��6�   
���   ���6�   Z� .��5/   &     $ delete=�6>   50   #   53      �� 54      -   5        $ btnSalir��54   %   $��10,0,10,0.4q�67   $��Right=�6L   
���   �$��60��6|   $
��auto��6�   
���   ���6�   Z� .��55   "     $ Close=�6:   56      58      �� 59      $��1��6%   $��1��65   $��10q�6C   .+�5:      �� -   5         ��Name$ 	txbnombre��5:   ;   $��	10 0 0 20q�6(    $  MaterialDesignHeadline4TextBlock#��[ 6N   $��Datos del empleado��6�   �� 5;      $��
 50 0 50 0q�6(   �� 5<      $��5q�6)   ���	#FFF1EFEF$ 
Horizontal=�6K   .+�5=   "   ��  $  MaterialDesignSubtitle1TextBlock#��[ 6,   $��10 10  30 10q�6f   $��Nombre:��6|   �� 5>   "   -   5        $ 	txbNombre��5>   ,   #��[ 6?   $��10q�6y   $��0��6�   5@      �� 5A      $��5q�6)   $ 
Horizontal=�64   ���	#FFF1EFEF.+�5B   "   �� #��[ 6,   $��10 10  30 10q�6f   $��	Apellido:��6|   �� 5C   "   -   5        $ txbApellido��5C   ,   #��[ 6A   $��10q�6{   $��0��6�   5E      �� 5F      ���	#FFF1EFEF$��5q�6@   .+�5G   "   �� -   5        $ txbTipoUsuario��5G   ,   #��[ 6D   $��10 10  30 10q�6~   $ ��Empleado con tipo Usuario:��6�   5I      �� 5L      $��5q�6)   $ 
Horizontal=�64   ���	#FFF1EFEF.+�5M   "   �� #��[ 6,   $��10 10  30 10q�6f   $��Fecha Nacimiento��6|   �� 5N   "   -   5        $ txbFechaNacimiento��5N   ,   #��[ 6H   $��10q�6�   $��0��6�   5P      �� 5Q      $��5q�6)   ���	#FFF1EFEF$ 
Horizontal=�6L   .+�5R   "   �� #��[ 6,   $��10 10  30 10q�6f   $��
Direccion:��6|   �� 5S   "   -	   5        $ txbDireccion��5S   ,   #��[ 6B   $��10q�6|   $��0��6�   5U      �� 5V      $ 
Horizontal=�6)   .+�5X   "   �� $��5q�6-   ���	#FFF1EFEF$ 
Horizontal=�6P   .+�5Y   &   �� #��[ 60   $��10 10  30 10q�6j   $��	Telefono:��6�   �� 5Z   &   -
   5        $ txbTelefono��5Z   0   #��[ 6E   $��10q�6   $��0��6�   5\   #   �� 5]   "   $��5q�6-   ���	#FFF1EFEF$ 
Horizontal=�6P   .+�5^   &   �� #��[ 60   $��10 10  30 10q�6j   $��Genero��6�   �� 5_   &   -   5        $ 	txbGenero��5_   0   #��[ 6C   $��10q�6}   $��0��6�   5`   #   5a      �� 5f      ���	#FFF1EFEF$��5q�6@   $ 
Horizontal=�6K   .+�5g   "   �� #��[ 6,   $��10 10  30 10q�6f   $��Correo:��6|   �� 5h   "   -   5        $ 	txbCorreo��5h   ,   #��[ 6?   $��10q�6y   $��0��6�   5i      5m      �� 5n      $��10q�6%   $��1��61   $��0��6>   ���#F7F7F7.+�5p      �� $��10q�6$   5q      5w      5z      5|      5}      5~      5      