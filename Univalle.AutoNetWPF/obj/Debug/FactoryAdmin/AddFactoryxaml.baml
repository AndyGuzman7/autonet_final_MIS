   M S B A M L   `   `   `  ����N  JUnivalle.AutoNetWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Univalle.AutoNetWPF.FactoryAdmin Univalle.AutoNetWPF.FactoryAdmin  5   	   5    /Univalle.AutoNetWPF.FactoryAdmin.AddFactoryxaml   5   	   n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Univalle.AutoNetWPF.FactoryAdmin     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � WindowState$ 	Maximized=�5   	   $
��auto��5   	   $
��auto��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	    � AllowsTransparency .  � WindowStyle$
 None=�5   	   ��5   	   Z� .��5      � ��6   Z� .+�5   
   �  J� Opacity$	 0.5Q�6   
���   �5      #  MaterialDesignThemes.Wpf.Card  5    
   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�6   $	��250��6O   $	��500��6\   	   UniformCornerRadius$	 15Q�6h   .��5"      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase
   OpeningEffectsOffset
 62   O  IMaterialDesignThemes.Wpf.Transitions.IndexedItemOffsetMultiplierExtension  *
0:0:0.05+   OpeningEffects 5#      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  5%         Kind$ SlideInFromLeft=�66   .��5*      � $
��auto��6   $
��auto��6%   .+�5+      ��  �� CornerRadius$ 15��6   ._�5,      �  � ColumnDefinitions 5-      �� 5/   "   $��* �63   .+�5?        $��10 80 10 10q�62   $��15q�6G   $��1��6T   $��1��6d   $	 15Q�6q   .��5A   "   �� .+�5E   &     $	 15Q�6P   $��5q�6j   ��6:   Z� .��5F   *   �� .+�5G   .   �� -   5         ��Name$ txtNombreFabrica��5G   A   $��5q�66   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nombre Fabrica o Marca��6[    ! MaterialDesignOutlinedTextBox#��[ 6�   ���#F7F7F7��6�   Z� 5H   +   5I   '     5J   &   $	 15Q�6P   $��5q�6j   ��6:   Z� .��5K   *   �� .+�5L   .   �� -   5        $  txtNombreCiudadProcedencia��5L   A   $��5q�66   $ Pais o Ciudad procedencia��6e   #��[ 6�   ���#F7F7F7��6�   Z� 5M   +   5N   '   5U   #   5V      �� 5X       �� Padding$ 15q�6%   $��2��62   $ 	15 0 0 15��6F   5Z      �� 5[      $��3��6%   $ 	15  0 0 0��69   ���	#FF2D3238$	��Top=�6j   $��70��6�   ._�5\   "   � .+�5]   &   ��  $  MaterialDesignHeadline5TextBlock#��[ 61   $��Center=�6k    �� Padding$ 23q�6�   
�������$��Añadir Fabrica o Marca��6�   �� 5^   &    �� Orientation$ 
Horizontal=�61   $��2��6J   $��Right=�6^   $��0 0 10 0q�6z   .+�5_   *   �� -   5         ��Name$ 	btnGuadar��5_   1   
���   �$��60��6Z   $��40��6e   
���   �
�������$��Right=�6�   .��5`   .   '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ ContentSave=�6F   5a   +   �� 5b   *   -   5        $ btnSalir��5b   1   $��
10 0 10 0 q�6C   
���   �$��60��6k   $��40��6v   
���   �
�������.��5c   .   	  $ Close=�6F   5d   +   5f   '   5g   #   5i      '
  !MaterialDesignThemes.Wpf.Snackbar
  5j      -   5         
 Name$ snackbarMessage��5j   `   ���	#FF175CC1$��	20 0 20 0q�6M    
  IsActive .  $��Stretch=�6�    
  Message. 5k   "   .  (MaterialDesignThemes.Wpf.SnackbarMessage  -   5        $��
sBMMensaje��5k   A   
�������$&�� ¡Repuesto Modificado con exito!��6f   5l      5n      5p      5q      5r      5s      5t      5u      