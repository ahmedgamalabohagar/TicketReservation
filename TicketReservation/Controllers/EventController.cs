﻿using AutoMapper;
using BLL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using TicketReservation.Models;
using TicketReservation.Utitly;

namespace TicketReservation.Controllers
{
    public class EventController : Controller
    {
        private readonly EventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventController(EventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        // GET: EventController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EventController/Details/5
        public ActionResult Details(int id)
        {
            return View(_mapper.Map<EventVM>(_eventRepository.GetbyId(id)));
        }


        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventVM eventVM)
        {
            try
            {
                if (eventVM.Image is not null)
                    eventVM.ImageName = DocumentSetting.UploadFile(eventVM.Image, "Images");
                _eventRepository.Add(_mapper.Map<Event>(eventVM));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(nameof(Index), eventVM);
        }

        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_mapper.Map<EventVM>(_eventRepository.GetbyId(id)));
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventVM eventVM)
        {
            if (id != eventVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    if (eventVM.Image is not null)
                    {
                        if (!string.IsNullOrEmpty(eventVM.ImageName))
                            DocumentSetting.DeleteFile(eventVM.ImageName, "Images");
                        eventVM.ImageName = DocumentSetting.UploadFile(eventVM.Image, "Images");
                    }

                    _eventRepository.Update(_mapper.Map<Event>(eventVM));
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(eventVM);
        }

        // GET: EventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_mapper.Map<EventVM>(_eventRepository.GetbyId(id)));
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EventVM eventVM)
        {
            if (id != eventVM.Id)
                return BadRequest();
            try
            {
                _eventRepository.Delete(_mapper.Map<Event>(eventVM));
                if (eventVM.ImageName is not null)
                    DocumentSetting.DeleteFile(eventVM.ImageName, "Images");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(eventVM);
        }
    }
}
