<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Youtube.ascx.cs" Inherits="atomicf1.controls.Youtube" %>

<div class="YoutubePanel">
    <iframe title="YouTube video player" width="370" height="300" src="http://www.youtube.com/embed/<%= VideoId %>" frameborder="0" allowfullscreen></iframe>
    <div class="summary">
        <%= Summary %>
    </div>        
</div>