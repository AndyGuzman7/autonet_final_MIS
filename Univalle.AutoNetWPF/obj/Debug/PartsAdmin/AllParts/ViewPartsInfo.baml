   M S B A M L   `   `   `  ����N  JUnivalle.AutoNetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Univalle.AutoNetWPF.PartsAdminUnivalle.AutoNetWPF.PartsAdmin  5   	   .    (Univalle.AutoNetWPF.PartsAdmin.ViewParts   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Univalle.AutoNetWPF.PartsAdmin     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�5        MaterialDesignFont#���  5       � WindowStyle$
 None=�6@    � WindowState$ 	Maximized=�6j   $	��600��6�   $
��1000��6�    � WindowStartupLocation$ CenterScreen=�6�    � 
ResizeMode$ NoResize=�6�    � AllowsTransparency . ��5   	   Z� .��5      � ��6   Z� .+�5   
   �  J� Opacity$	 0.5Q�6   
���   �5      )  #MaterialDesignThemes.Wpf.DialogHost  5   
     MaterialDesignDivider#���  6$   	   DialogContent	 5      � 5      $	��300��6   $	��150��6#   $��Center=�60   .+�5      �� .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 Folder=�62     PrimaryHueDarkBrush#��[ 6@   $��50��6r   $��50��6}   �� 5      
�������$	��200��66   $
��15 5q�6B   $
��Wrap=�6P   Desea eliminar5      5      �� 5       $��Right=�6!   $��Bottom=�6=   $��15q�6X   .+�5!      ��    CloseDialogCommand#��Z 6!     MaterialDesignFlatButton#���  6c   $��4q�6�   $��Center=�6�   .��6�   
Cancelar5#      �� 5$      -   5        #��Z 5$   !   #���  6c   $��4q�6�   $��Center=�6�   .��6�   	Aceptar5&      5'      5)      .��5+      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 20Q�6"   $	��500��6;   $	��900��6H   .��5,      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5-      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5.         Kind$ FadeIn=�6:     5/      $ SlideInFromBottom=�6:   .��51      � $	��500��6   $	��900��6*   ��67   Z� .+�52      ��  �� CornerRadius$ 15��6!   
�������._�53      � $��20q�6$    � ColumnDefinitions 54   "   �� 55   &   $��* �67   �� 56   &   $
��1.3* �67    � RowDefinitions 58   "   �� 59   &   $��30 �64   �� 5:   &   $��* �64   .+�5<   "   � $��2��6*   .+�5=   &   ��  �� Orientation$ 
Horizontal=�62   $��Right=�6L   $��
0,0,10,0.4q�6h   $	��820��6|   .+�5>   *   �� -   5         ��Name$ 	btnEditar��5>   1   
���   �$��60��6Y   $
��auto��6d   
���   �$��Right=�6�   ��6�   Z� .��5?   .     $

 Edit=�6F   5@   +   �� 5A   *   -   5        $ btnEliminar��5A   1      OpenDialogCommand#��Z 6F   $��	10 0 10 0q�6�   $��Right=�6�   
���   �$��60��6�   $
��auto��6�   
���   ���6�   Z� .��5B   .     $
 delete=�6F   5C   +   5E   '   �� 5G   &   -   5        $ btnSalir��5G   -   $��10,0,10,0.4q�6?   $��Right=�6T   
���   �$��60��6�   $
��auto��6�   
���   ���6�   Z� .��5H   *     $
 Close=�6B   5I   '   5K   #   �� 5L   "   $��1��6-   $��1��6=   $��10q�6K   .+�5M   &   �� -   5         ��Name$ 	txbnombre��5M   C   $��	10 0 0 50q�60    $  MaterialDesignHeadline4TextBlock#��[ 6V   $��Titulo��6�   �� 5N   &   $��
 10 0 10 0q�60   �� 5O   &   $��5q�61   .+�5P   *   �� -   5        $��lblPrecioBase��5P   E   $��10 10 10 10q�60   $
��0 bs��6Z   5Q   '   �� 5S   &   $��
 10 0 10 0q�60   �� 5T   &   $��5q�61   $ 
Horizontal=�6<   .+�5U   *   ��  $  MaterialDesignSubtitle1TextBlock#��[ 64   $��10 10  30 10q�6n   $��Cantidad Stock:��6�   �� 5V   *   -   5        $ txbCantidaStock��5V   4   #��[ 6M   $��10q�6�   $��0��6�   5X   '   �� 5Y   &   $��
 10 0 10 0q�60   �� 5Z   &   $��5q�61   $ 
Horizontal=�6<   .+�5[   *   �� #��[ 64   $��10 10  30 10q�6n   $��Peso:��6�   �� 5\   *   -	   5        $ txbPeso��5\   4   #��[ 6E   $��10q�6   $��0��6�   5^   '   �� 5_   &   $��
 10 0 10 0q�60   �� 5`   &   $��5q�61   $ 
Horizontal=�6<   .+�5a   *   �� #��[ 64   $��10 10  30 10q�6n   $��Codigo Producto:��6�   �� 5b   *   -
   5        $ txbCodigoProducto��5b   4   #��[ 6O   $��10q�6�   $��0��6�   5d   '   �� 5e   &   $��
 10 0 10 0q�60   �� 5f   &   $��5q�61   $ 
Horizontal=�6<   .+�5g   *   �� #��[ 64   $��10 10  30 10q�6n   $��Fabrica o Marca:��6�   �� 5h   *   -   5        $ txbMarca��5h   4   #��[ 6F   $��10q�6�   $��0��6�   5i   '   �� 5j   &   $��
 10 0 10 0q�60   �� 5k   &   $��5q�61   $ 
Horizontal=�6<   .+�5l   *   �� #��[ 64   $��10 10  30 10q�6n   $��Tipo Repuesto��6�   �� 5m   *   -   5        $ txbTipoRepuesto��5m   4   #��[ 6M   $��10q�6�   $��0��6�   5o   '   5q   #   �� 5r   "   $��10q�6-   $��1��69   $��0��6F   ���#F7F7F7.+�5t   &   �� $��10q�6,   $5��//PartsAdmin/image/logo2Recurso 12logoBalnco.png��69   5u   #   5{      5~      5�      5�      5�      5�      5�      5�      