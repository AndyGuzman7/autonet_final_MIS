   M S B A M L   `   `   `  ����N  JUnivalle.AutoNetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Univalle.AutoNetWPF.PartsAdminUnivalle.AutoNetWPF.PartsAdmin  5   	   -    'Univalle.AutoNetWPF.PartsAdmin.AddParts   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Univalle.AutoNetWPF.PartsAdmin     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5       � WindowState$ 	Maximized=�6@   $
��auto��6X   $
��auto��6f    � WindowStartupLocation$ CenterScreen=�6s    � 
ResizeMode$ NoResize=�6�    � AllowsTransparency .  � WindowStyle$
 None=�6�   ��5      Z� .��5      � ��6   Z� .+�5   
   �  J� Opacity$	 0.5Q�6   
���   �5      #  MaterialDesignThemes.Wpf.Card  5   
   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�6   $	��650��6O   $	��780��6\   	   UniformCornerRadius$	 15Q�6h   .��5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase
   OpeningEffect
 62   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *
ExpandIn+.��5      � $
��auto��6   $
��auto��6%    � ColumnDefinitions 5      �� 5      .+�5"      ��  �� CornerRadius$ 15��6   $��0��6/   ._�5#      �  5$      �� 5&   "   $��* �63   �� 5'   "   $��* �63   .+�5)      �� $��0 80 0 0q�6&    �� Padding$ 15q�68   $ Depth3=�6E   $��0��6v   $ 
 0 15 15 0��6�   ���#F7F7F7._�5+   "   �� .+�5,   &     
�������$	 15Q�6M   $��10q�6f   $��5q�6s   .��5-   *   �� .+�5.   .   � $��5q�63   ���#F7F7F7 5/   2   �� 50   6   $��* �6G   �� 51   6   $
��auto �6G   .+�53   2   �� -   5         ��Name$ stackPanelButtons��53   =   $y�	Collapsed=�6X    �� Orientation$ Vertical=�6o   $��1��6�   $��Center=�6�   .+�54   6   �� -   5         ��Name$ btnTomarFotografia��54   =   $��1��6q   $��0q�6�   $��30��6�   $��30��6�   $��10q�6�   
���   ���6Y   Z� ��6�   Z� .��55   :   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ camera=�6R   $��30��6`   $��30��6k   56   7   �� 57   6   -   5        $ btnTomarNuevaFoto��57   =   $��1��6p   $��0q�6�   $��30��6�   $��30��6�   $��10q�6�   
���   ���6X   Z� ��6�   Z� .��58   :     $ Reload=�6R   $��30��6`   $��30��6k   59   7   5:   3   �� 5<   2   -   5         ��Name$ imgSpare��5<   8   $��10q�6J   $
��auto��6V   $	��150��6d   5>   3   5?   /   � 5A   .    5B   2   �� 5C   6   �� 5D   6   .+�5F   2   �� -   5        $ btnAñadirImagen��5F   9   $��5q�6R   ���	#FF175CC1$��Añadir de Galeria��6�   
�������$��Normal"�6�   ��6]   Z� 6�   �� 5G   2   -   5        $ btnAñadirImagenGaleria��5G   9   $��1��6Y   $��5q�6i   ���	#FF175CC1$��Añadir con camara��6�   
�������$��Normal"�6�   ��6t   Z� 6�   5I   /   5L   .   5M   '     5Q   &   
�������$	 15Q�6M   $��10q�6f   $��5q�6s   .��5R   *   �� .+�5S   .   �� -   5         ��Name$ txtNombreProducto��5S   6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre Producto��6Q    ! MaterialDesignOutlinedTextBox#��[ 6�   ���#F7F7F7��6�   Z� 5T   +   5U   '     5W   &   
�������$	 15Q�6M   $��10q�6f   $��5q�6s   .��5X   *   �� .+�5Y   .   �� -	   5        $ txtDescripcion��5Z   -   ���#F7F7F7#��[ 5\   1   $	��Top=�5]   1   $	��100��5^   1    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5`   1   " �� VerticalScrollBarVisibility$
 Auto=�5a   1   $ Descripcion��5b   1   ��5[   F   Z� {�5c   1   ��  �� Path$ 	IsChecked� �� ElementName$2 ,MaterialDesignOutlinedTextBoxEnabledComboBox��5e   +   5g   '   5p   #   5q      �� 5r      $��0 80 0 0q�6&   $ 15q�68   $ Depth3=�6E   $��1��6v   $ 
 0 15 15 0��6�   ���#F7F7F7._�5t   "   �� .+�5v   &   �� $��10q�60   $y�	Collapsed=�6<    $  MaterialDesignHeadline5TextBlock#��[ 6S   $��Acerca del Proveedor��6�     5x   &   
�������$y�	Collapsed=�6M   $	 15Q�6d   $��10q�6}   $��5q�6�   .��5y   *   �� .+�5z   .   �� -
   5         ��Name$ cmbTipoUsuario��5z   B   $��5q�67   $ Nombre Proveedor��6[      MaterialDesignFilledComboBox#��[ 6�   {�6�   �� $ 	IsChecked�$# FilledComboBoxEnabledCheckBox��5{   +   5|   '   �� 5}   &   $��10q�60   #��[ 6<   $��Datos de Compra��6v     5�   &   
�������$	 15Q�6M   $��10q�6f   $��5q�6s   .��5�   *   �  5�   .   �� 5�   2   $��* �6C    � RowDefinitions 5�   .   �� 5�   2   �� 5�   2   �� 5�   2   .+�5�   .   �� -   5        $ txtSaldoActual��5�   6   $��0��6N   $
��0 10q�6^   $ SaldoActual��6m   #��[ 6�   ���#F7F7F7$
��auto��6�   ��6�   Z� �� 5�   .   -   5        $ txtPrecioBase��5�   6   $��1��6M   $��1��6Z   $
��0 10q�6j   $ Precio Base��6x   #��[ 6�   ���#F7F7F7$
��auto��6�   ��6�   Z� �� 5�   .   -   5        $ txtPeso��5�   6   $��2��6G   $��2��6W   $
��0 10q�6d   $
 Peso��6r   #��[ 6�   ���#F7F7F7$
��auto��6�   ��6�   Z� 5�   +   5�   '     5�   &   
�������$	 15Q�6M   $��10q�6f   $��5q�6s   .��5�   *   �� .+�5�   .   �� -   5        $ txtCodigoProducto��5�   6   $ Codigo de Producto��6Q   #��[ 6�   ���#F7F7F7��6�   Z� 5�   +   5�   '     5�   &   
�������$	 15Q�6M   $��10q�6f   $��5q�6s   .��5�   *   �  5�   .   �� 5�   2   $��* �6C   �� 5�   2   $��* �6C   .+�5�   .   �� -   5        $ txtMarca��5�   6   $ Fabrica o Marca��6H   #��[ 6y   ���#F7F7F7��6�   Z� �� 5�   .   -   5        $ txtTipo��5�   6   $��1��6G   $ Tipo de Repuesto��6W   #��[ 6�   ���#F7F7F7��6�   Z� 5�   +   5�   '   5�   #   5�      �� 5�      $ 15q�6%   $��2��62   $ 	15 0 0 15��6F   5�      �� 5�      $��3��6%   $ 	15  0 0 0��69   ���	#FF2D3238$	��Top=�6j   $��70��6�   ._�5�   "   � .+�5�   &   �� #��[ 61   $��Center=�6k    �� Padding$ 23q�6�   
�������$��Añadir Repuesto��6�   �� 5�   &   $ 
Horizontal=�61   $��2��6J   $��Right=�6^   $��0 0 10 0q�6z   .+�5�   *   �� -   5        $ 	btnGuadar��5�   1   
���   �$��60��6Z   $��40��6e   
���   �
�������$��Right=�6�   .��5�   .     $ ContentSave=�6F   5�   +   �� 5�   *   -   5        $ btnSalir��5�   1   $��
10 0 10 0 q�6C   
���   �$��60��6k   $��40��6v   
���   �
�������.��5�   .     $ Close=�6F   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      