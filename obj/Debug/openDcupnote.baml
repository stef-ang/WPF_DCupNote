   M S B A M L   `   `   `  ����  WPF_DCupNote    WPF_DCupNote.openDcupnote   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          �Name$  
openWindow��5   	    � Title$ openDcupnote��5   	   $	��500��6   $
��1000��6+    � WindowStyle$
 None=�5   	    � 
ResizeMode$ CanResizeWithGrip=�6    � AllowsTransparency . $��2q�5   	   
���   �.��5      �  � RowDefinitions 5	   
   �� 5
      $��27 �6   �� 5      $
��135* �6   .+�5   
   � -   5        $��0��5      
�������.+�5      �� $��10,2,0,1q�6   $
��Left=�6*   $��Center=�6E   $��Open d'Cupnote��6`   $
��Bold"�6v   $��18(�6�   $��Italic$�6�   $	��954��6�   �� 5      -   5         ��Name$ closeBtn��5      $��X��6'   $��Right=�63   $	��Top=�6O   $
��Bold"�6g   $��27��6y   ���	#FFFF5E5E$��27��6�    K� ZIndex$ 1��6�   $��16(�6�    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5      	   
KernelType$		 Box=�6!   
   Radius$
 1Q�62      RenderingBias$ Quality=�6=   5      5      � 5   
   
�������$��1��6&   .+�5      (  "Xceed.Wpf.Toolkit.WatermarkTextBox     	Watermark$ Search:��6$   $��Right=�68   $��23��6T   $��	0,10,10,0q�6`   $�� ��6s   $	��Top=�6{   $	��196��6�   �� 5      ���	#FF0046FF$��1q�6-   $��Stretch=�6A   $��10,38,10,10q�6_   $��Stretch=�6t   ._�5      �� $
��Auto=�6   .��5      � -   5         �Name$ 	wrapPanel��5       $��Stretch=�63   $��Stretch=�6Q   
������� � Orientation$ 
Horizontal=�6�   5      5      5      5      5      