   M S B A M L   `   `   `  ����H  DThreadManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ThreadApp.ViewModelsThreadApp.ViewModels  5   	        ThreadApp.Views.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9
viewModels"clr-namespace:ThreadApp.ViewModels     5   	     � Title$  
Thread App��5   	   $	��450��6   $	��600��6)    � DataContext 5      (   "ThreadApp.ViewModels.MainViewModel  5   
   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Inactive Threads��6   $��Center=�6+   $��0��6H   �� 5   
   $��0��6b   ��6   �� *InactiveThreads+ �� SelectedItem 6:   �� *SelectedThread+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� ��6$   �� *Name+�� 5      $��10,0,0,0q�6<   ��6$   �� *Status+6<   5      5      5      �� 5   
   $ 
Horizontal=�6   $��Center=�6.   $��1��6K   .+�5      �� $��
Add Thread��6   $��5q�6*   ��65   �� *AddThreadCommand+�� 5      $
��Play��6   $��5q�6$   ��6/   �� *PlayThreadCommand+�� 5      $��Pause��6   $��5q�6%   ��60   �� *PauseThreadCommand+�� 5       $��Resume��6   $��5q�6&   ��61   �� *ResumeThreadCommand+�� 5!      $
��Stop��6   $��5q�6$   ��6/   �� *StopThreadCommand+5"      �� 5$   
   $��Processing Threads��6   $��Center=�6-   $��2��6J   �� 5%   
   $��2��6d   ��6   �� *ProcessingThreads+ 6<   �� *SelectedThread+��5&      �� 5'      .R�5(      �� $ 
Horizontal=�6!   .+�5)      �� ��6$   �� *Name+�� 5*      $��10,0,0,0q�6<   ��6$   �� *Status+6<   5+      5,      5.      5/      50      