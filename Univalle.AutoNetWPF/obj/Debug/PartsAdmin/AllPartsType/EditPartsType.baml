   M S B A M L   `   `   `  ����N  JUnivalle.AutoNetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Univalle.AutoNetWPF.PartsAdminUnivalle.AutoNetWPF.PartsAdmin  5   	   2    ,Univalle.AutoNetWPF.PartsAdmin.EditPartsType   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:Univalle.AutoNetWPF.PartsAdmin     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5       � WindowState$ 	Maximized=�6>   $
��auto��6V   $
��auto��6d    � WindowStartupLocation$ CenterScreen=�6q    � 
ResizeMode$ NoResize=�6�    � AllowsTransparency .  � WindowStyle$
 None=�6�   ��5      Z� .��5      � ��6   Z� .+�5   
   �  J� Opacity$	 0.5Q�6   
���   �5      #  MaterialDesignThemes.Wpf.Card  5   
   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�6   	   UniformCornerRadius$	 15Q�6O   $	��650��6h   $	��470��6t   .��5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase
   OpeningEffect
 62   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *
ExpandIn+.��5      � $
��auto��6   $
��auto��6%   .+�5      ��  �� CornerRadius$ 15��6   ._�5      �  � ColumnDefinitions 5      �� 5   "   $��* �63   �� 5    "   $��* �63   .+�5#      �� $	��top=�6%    �� Padding$ 15q�6=   $��0 80 0 0q�6J   $ Depth3=�6\   $��2��6�   $  0 120 15 0��6�   ���#F7F7F7._�5%   "   �� .+�5&   &     
�������$	 15Q�6M   $��10q�6f   $��5q�6s   .��5'   *   �� .+�5(   .   � $��5q�63   ���#F7F7F7.+�5)   2   �� $��10q�68   $��70��6D   $5��//PartsAdmin/image/logo2Recurso 12logoBalnco.png��6O   5+   3   5,   /   �� 5/   .   $��5q�65   ���	#FF175CC1$��Añadir Imagen��6r   
�������$��Normal"�6�   ��6@   Z� 6�   50   +   51   '     55   &   
�������$	 15Q�6M   $��10q�6f   $��5q�6s   .��56   *   �� .+�57   .   �� -   5        $��txtNombreTipoProducto��57   6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre Tipo Repuesto��6S    ! MaterialDesignOutlinedTextBox#��[ 6�   ���#F7F7F7��6�   Z� 58   +   59   '     5:   &   
�������$	 15Q�6M   $��10q�6f   $��5q�6s   .��5;   *   �� .+�5>   .   �� -   5         ��Name$ txbCategoria��5>   6   $ 	Categoria��6L   #��[ 6w   ���#F7F7F7��6�   Z� 5@   +   5B   '   5G   #   5H      �� 5J      $ 15q�6%   $��2��62   $ 	15 0 0 15��6F   5P      �� 5Q      $��3��6%   $ 	15  0 0 0��69   ���	#FF175CC1$	��Top=�6j   $��70��6�   ._�5R   "   � .+�5S   &   ��  $  MaterialDesignHeadline5TextBlock#��[ 61   $��Center=�6k    �� Padding$ 23q�6�   
�������$��Area de Edicion��6�   �� 5T   &    �� Orientation$ 
Horizontal=�61   $��2��6J   $��Right=�6^   $��0 0 10 0q�6z   .+�5U   *   �� -   5         ��Name$ 	btnGuadar��5U   1   
���   �$��60��6Z   $��40��6e   
���   �
�������$��Right=�6�   .��5V   .   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ContentSave=�6F   5W   +   �� 5X   *   -   5        $ btnSalir��5X   1   $��
10 0 10 0 q�6C   
���   �$��60��6k   $��40��6v   
���   �
�������.��5Y   .     $ Close=�6F   5Z   +   5\   '   5]   #   5_      5`      5a      5b      5c      5d      5e      5f      