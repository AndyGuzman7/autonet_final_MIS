   M S B A M L   `   `   `  ����N  JUnivalle.AutoNetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Univalle.AutoNetWPF.PersonasAdmin!Univalle.AutoNetWPF.PersonasAdmin  5      1    +Univalle.AutoNetWPF.PersonasAdmin.uscClient   5      n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Alocal/clr-namespace:Univalle.AutoNetWPF.PersonasAdmin     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -   5           MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      $��Montserrat Regular)�5      .��5      � .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5         Kind$ FadeIn=�62     5      $ SlideInFromBottom=�62   .��5      � $
��auto��6   $
��auto��6!   .+�5      ��  �� CornerRadius$ 15��6   
�������._�5      � .+�5      � $��	0  10 0 0q�6    $��60��63   $	��top=�6?   ���#F7F7F7.+�5       ��  �� Orientation$ 
Horizontal=�6)   .+�5!   "   �� -   5         ��Name$ btnAgregarCliente��5!   c   
��� � �$	��100��6<   $
��Left=�6H   $��20,0,10,0.4q�6~   $��0q�6�   .��5"   &   �� $��Center=�61   .+�5#   *   �� $
��auto��65   $ 
Horizontal=�6C   .+�5%   .   �� $��Center=�68   $��	+ Cliente��6S   $��5q�6e   $
��auto��6p   5'   +   5)   '   5,   #   �� 5.   "   $ 
Horizontal=�6-   $��Center=�6F   .+�50   &   (  "MaterialDesignThemes.Wpf.ColorZone  $	��500��6?      Mode$ Standard=�6K   $��8 4 8 4q�6[      CornerRadius$ 2��6m   	 K� ZIndex$	 1��6~   $��16 0 0 0q�6�   +  %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth1=�6�   .��51   *   �  � ColumnDefinitions 52   .   �� 53   2   $
��Auto �6D   �� 54   2   $��* �6D   �� 55   2   $
��Auto �6C   .+�57   .   � $��Center=�63   .+�58   2   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�6K    J� Opacity$	 .56Q�6Y   59   /   �� 5:   .   -   5         ��Name$ txtNombreBuscar��5:   6   $��1��6O   $��8 0 0 0q�6_   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Buscar Clientes��6q   .	  (MaterialDesignThemes.Wpf.TextFieldAssist 	  DecorationVisibility$ Hidden=�6�   $��0q�6�   $	��200��6�   $��Center=�6  6  5<   +   5=   '   �� 5>   &   -   5        $��	btnBuscar��5>   �    & "MaterialDesignToolForegroundButton#���  6-   $��8 0 0 0q�6j   $	 0��6|   .��5?   *     $
 Send=�6C   5@   '   5A   #   5C      5E      � 5F      -   5         �Name$ gridMainParts��5F      $��20 90 20 20q�66   .+�5J      �� $��Visible=�6+   .��5K   "   � -   5        $ 	gridParts��5K   '   $	��Top=�6;   .+�5L   &   � $��
20,0,20,20q�60   $��Center=�6D   .+�5M   *   &
   System.Windows.Controls.DataGrid
  -   5        $��dataGridProgram��5M   c    
  AutoGenerateColumns .  
������� 
  SelectionMode$ Single=�6z   $��15(�6�    
  
IsReadOnly . $
��auto��6�   $	��700��6�    
  CanUserAddRows .  ��.  
  Columns 5O   .   0  *System.Windows.Controls.DataGridTextColumn  5P   2   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6E      Header$ Id��6O      
Visibility$ 	Collapsed=�6   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6[   ��  �� Path$ idClient�6     5Q   2   -   5        dtdd��$ * 5Q   S   $	 Nit��6^    6l   �� $	 nit�  5S   2   $ * 6E   $ Nombres��6O    6`   �� $ 	firstName�  5T   2   $ * 6E   $ Apellido��6O    6b   �� $ lastName�4  .System.Windows.Controls.DataGridTemplateColumn  5U   2   $ Editar��6I      CellTemplate 5V   6   �� 5W   :   .R�5X   >   �� $��btnEditarCiente��6E   -	   5        $��40��5X   \   $��Editar��6h   
��� �����6�   Z� 5Y   ;   5[   3     5\   2   $ Borrar��6I    5]   6   �� 5^   :   .R�5_   >   �� $��btnBorrarCliente��6E   -
   5        $��40��5_   ]   $��Borrar��6i   
���  ����6�   Z� 5`   ;   5b   3   5e   +   5f   '   5g   #   5h      5i      5m      5v      )  #MaterialDesignThemes.Wpf.DialogHost  5w      -   5        $��DialogoHost1��5w   ,     MaterialDesignDivider#���  6@      DialogContent 5x      � 5y      .+�5z      �� $ 15��6%   $	��300��67   $	��150��6C   $��Center=�6P   
�������._�5{   "   �  5|   &   �� 5}   *   �� 5~   *    � RowDefinitions 5�   &   �� 5�   *   �� 5�   *   .+�5�   &   �� $��2��60   $��Center=�6D   $��Center=�6_   $"��¿Desea Eliminar el cliente?��6|   �� 5�   &   -   5        $  btnCancelarEliminarCliente��5�   -   $��1��6Q   $��Cancelar��6^   $��10q�6q   ���	#FF17950A���	#FF1A6C086�   �� 5�   &   -   5        $ btnEliminarCliente��5�   -   $��1��6I   $��Eliminar��6V   $��10q�6i   $��1��6u   ���	#FFDA1F1F���	#FFAC0B0B6�   5�   #   5�      5�      5�      '  !MaterialDesignThemes.Wpf.Snackbar  5�      -   5          Name$ snackbarMessage��5�   T   ���	#FF175CC1$��	20 0 20 0q�6A       IsActive  .  $��Stretch=�6~   !   Message.! 5�      .  (MaterialDesignThemes.Wpf.SnackbarMessage  -   5        $��
sBMMensaje��5�   5   
�������$&�� ¡Repuesto Modificado con exito!��6Z   5�      5�      5�      5�      5�      