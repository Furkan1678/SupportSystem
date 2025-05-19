import React from 'react';
import { Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import Login from './pages/Login';
import Register from './pages/Register';
import SupportRequests from './pages/SupportRequests';
import CreateSupportRequest from './pages/CreateSupportRequest';
import SupportRequestDetail from './pages/SupportRequestDetail';
import Notifications from './pages/Notifications';
import AdminDashboard from './pages/AdminDashboard';
import AdminOverview from './pages/AdminOverview';
import AdminRequests from './pages/AdminRequests';
import AdminCategories from './pages/AdminCategories';
import AdminTypes from './pages/AdminTypes';
import AdminNotifications from './pages/AdminNotifications';
import AdminUsers from './pages/AdminUsers';
import NotFound from './pages/NotFound';

function RoutesComponent() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route path="/support-requests" element={<SupportRequests />} />
      <Route path="/create-support-request" element={<CreateSupportRequest />} />
      <Route path="/support-request/:id" element={<SupportRequestDetail />} />
      <Route path="/notifications" element={<Notifications />} />
      <Route path="/admin-dashboard" element={<AdminDashboard />}>
        <Route index element={<AdminOverview />} />
        <Route path="requests" element={<AdminRequests />} />
        <Route path="categories" element={<AdminCategories />} />
        <Route path="types" element={<AdminTypes />} />
        <Route path="notifications" element={<AdminNotifications />} />
        <Route path="users" element={<AdminUsers />} />
      </Route>
      <Route path="*" element={<NotFound />} />
    </Routes>
  );
}

export default RoutesComponent;